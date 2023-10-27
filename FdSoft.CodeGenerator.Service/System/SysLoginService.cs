using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Common.Extensions;
using SqlSugar;
using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Model.System.Dto;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Repository.System;
using FdSoft.CodeGenerator.Service.System.IService;
using FdSoft.CodeGenerator.Model.Models;
using System.Linq;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Service.Base;
using FdSoft.CodeGenerator.Model.Dto.Base;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using System.Security.Cryptography;
using FdSoft.CodeGenerator.Service.Material.IMaterialService;
using FdSoft.CodeGenerator.Model.Dto;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Policy;
using FdSoft.CodeGenerator.Common;
using Mapster;
using FdSoft.CodeGenerator.Common.Enums;

namespace FdSoft.CodeGenerator.Service.System
{
    /// <summary>
    /// 登录
    /// </summary>
    [AppService(ServiceType = typeof(ISysLoginService), ServiceLifetime = LifeTime.Transient)]
    public class SysLoginService : BaseService<SysLogininfor>, ISysLoginService
    {
        private readonly SysUserRepository SysUserRepository;
        private readonly JCUserRepository jCUserRepository;
        private readonly JCCorporationRepository jCCorporationRepository;
        private readonly JCRoleRepository jCRoleRepository;
        private readonly IJCCorporationService jCCorporationService;
        private readonly IJCProductService jCProductService;
        private readonly ISysMenuService sysMenuService;
        private readonly IJCPowerItemService jCPowerItemService;

        public SysLoginService(SysUserRepository sysUserRepository,
            JCUserRepository jCUserRepository,
            JCCorporationRepository jCCorporationRepository,
            JCRoleRepository jCRoleRepository,
            IJCCorporationService jCCorporationService,
            IJCProductService jCProductService,
            ISysMenuService systemService,
            IJCPowerItemService jCPowerItemService)
        {
            SysUserRepository = sysUserRepository;
            this.jCUserRepository = jCUserRepository;
            this.jCCorporationRepository = jCCorporationRepository;
            this.jCRoleRepository = jCRoleRepository;
            this.jCCorporationService = jCCorporationService;
            this.jCProductService = jCProductService;
            this.sysMenuService = systemService;
            this.jCPowerItemService = jCPowerItemService;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="dtoNew"></param>
        /// <returns></returns>
        public JCUser Login(LoginBodyDtoNew dtoNew, out LoginUserExtDto loginUserExtDto)
        {
            loginUserExtDto = new LoginUserExtDto() { ClientId = Guid.NewGuid() };
            //较验用户登录信息
            CheckUser(dtoNew);
            //登录信息
            RealLogin(dtoNew, loginUserExtDto);
            return dtoNew.User;
        }

        /// <summary>
        /// 较验用户登录信息
        /// </summary>
        /// <param name="dtoNew"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private JCUser CheckUser(LoginBodyDtoNew dtoNew)
        {
            JCUser jcUser = default;
            if (dtoNew is null)
                throw new CustomException(ResultCode.LOGIN_ERROR, "请求参数错误！");
            if (dtoNew.SwitchType == 0)
            {
                if (string.IsNullOrEmpty(dtoNew.UserName) || string.IsNullOrEmpty(dtoNew.PassWord))
                    throw new CustomException(ResultCode.LOGIN_ERROR, "用户名或密码错误不能为空！");

                //密码md5
                dtoNew.PassWord = NETCore.Encrypt.EncryptProvider.Md5(dtoNew.PassWord);

                jcUser = jCUserRepository.GetFirst(o => o.UserName == dtoNew.UserName && o.DeleteStatus == 0);
                if (Convert.ToInt32(jcUser?.UserId ?? default) == 0)
                    throw new CustomException(ResultCode.LOGIN_ERROR, "用户不存在！");

                if (jcUser.UserPwd.ToUpper() != dtoNew.PassWord.ToUpper())
                    throw new CustomException(ResultCode.LOGIN_ERROR, "用户或密码有误！");

                if (jcUser.Status == 1)
                    throw new CustomException(ResultCode.LOGIN_ERROR, "该用户已被锁定！");

            }
            else
            {
                jcUser = jCUserRepository.GetById(dtoNew.UserId);

                if (Convert.ToInt32(jcUser?.UserId ?? default) == 0)
                    throw new CustomException(ResultCode.LOGIN_ERROR, "用户不存在！");

                if (jcUser.Status == 1)
                    throw new CustomException(ResultCode.LOGIN_ERROR, "该用户已被锁定！");
            }
            dtoNew.UserId = jcUser.UserId;
            dtoNew.UserName = jcUser.UserName;
            dtoNew.PassWord = jcUser.UserPwd;
            dtoNew.User = jcUser;
            return jcUser;
        }

        /// <summary>
        /// 较验用户登录信息后登录逻辑
        /// </summary>
        /// <param name="dtoNew"></param>
        /// <param name="user"></param>
        /// <param name="loginUserExtDto"></param>
        /// <exception cref="CustomException"></exception>
        private void RealLogin(LoginBodyDtoNew dtoNew, LoginUserExtDto loginUserExtDto)
        {
            #region 锁定项目+锁定产品+基础较验
            var productAll = jCProductService.GetAllWithRedis();

            loginUserExtDto.IsAdmin = jCProductService.IsSuper(dtoNew.UserId);

            var corpAll = jCCorporationService.GetCorpListByUserId(dtoNew, loginUserExtDto.IsAdmin);

            var loginCorpList = productAll.Where(o => o.ProductType == dtoNew.ProductType).ToList();
            if (loginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "请先设置用户登录产品权限！");

            var loginProductIds = loginCorpList.Select(o => o.ProductCode.ParseToInt()).Distinct().ToList();
            var sonCorpList = jCCorporationService.GetSonCorpList(dtoNew, loginProductIds, corpAll, loginUserExtDto.IsAdmin);
            if (sonCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "登录用户角色权限配置信息不存在！");

            var canLoginCorpList = new List<CorpMemoryDto>();
            CorpMemoryDto corpMemoryDto = default;
            JCCorporation rootCorp = default;
            int rootCoId = default;
            var isCompany = false;
            //登录项目或企业
            if (dtoNew.SwitchType == 0)
            {
                canLoginCorpList = sonCorpList.Where(o => loginProductIds.Contains(o.ProductId)).OrderByDescending(o => o.CoId).ThenBy(o => o.ProductId).ThenByDescending(o => o.OrganizeType).ToList();
                if (canLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "登录项目或企业无权限！");

                //用户ProId为空
                ClearLoginProId:
                if (dtoNew.User.ProId.IsEmpty())
                {
                //用户企业为空
                ClearLoginCoId:
                    if (dtoNew.User.RootCoId.ParseToInt() == default)
                    {
                        if (dtoNew.ProductType == (int)ProductType.New)
                        {
                            corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目 && o.ProductId == dtoNew.User.ProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目 && o.ProductId == dtoNew.ToProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业 && o.ProductId == dtoNew.User.ProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业 && o.ProductId == dtoNew.ToProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业);
                            if (corpMemoryDto.IsNull())
                            {
                                corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.项目);
                                if (corpMemoryDto.IsNotNull()) ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
                                else
                                {
                                    //项目配置企业权限：暂时处理
                                    corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.企业);
                                    if (corpMemoryDto.IsNotNull()) ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
                                }
                            }
                        }
                        else if (dtoNew.ProductType == (int)ProductType.Old)
                        {
                            var tempLoginCorpList = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.CoType > 0).ToList();
                            corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.OrganizeType == (int)OrganizeType.项目 && o.ProductId == dtoNew.User.ProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.OrganizeType == (int)OrganizeType.项目 && o.ProductId == dtoNew.ToProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.OrganizeType == (int)OrganizeType.项目);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.User.ProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.ToProductId);
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault();
                        }
                    }

                    //用户企业不为空
                    else
                    {
                        //老版系统
                        if (dtoNew.ProductType == (int)ProductType.Old)
                        {
                            var tempLoginCorpList = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目 && o.ItemPath.IsNotEmpty() && o.ItemPath.Split(",").Select(int.Parse).Contains(dtoNew.User.RootCoId.Value)).ToList();
                            corpMemoryDto = tempLoginCorpList.Where(o => o.ProductId == dtoNew.User.ProductId).FirstOrDefault();
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.Where(o => o.ProductId == dtoNew.ToProductId).FirstOrDefault();
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault();
                        }

                        //新版系统
                        else
                        {
                            var tempLoginCorpList = canLoginCorpList.Where(o => o.CoId == dtoNew.User.RootCoId && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业).ToList();
                            corpMemoryDto = tempLoginCorpList.Where(o => o.ProductId == dtoNew.User.ProductId).FirstOrDefault();
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.Where(o => o.ProductId == dtoNew.ToProductId).FirstOrDefault();
                            if (corpMemoryDto.IsNull())
                                corpMemoryDto = tempLoginCorpList.FirstOrDefault();
                        }
                        if (corpMemoryDto.IsNull())
                        {
                            dtoNew.User.RootCoId = default;
                            goto ClearLoginCoId;
                        }
                    }
                }

                //用户ProId不为空
                else
                {
                    var tempLoginCorpList = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.ProId == dtoNew.User.ProId && o.CoType > 0).ToList();
                    if (dtoNew.User.ProductId.HasValue)
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.User.ProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.ToProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault();
                    if (corpMemoryDto.IsNull())
                    {
                        dtoNew.User.ProId = default;
                        goto ClearLoginProId;
                    }
                }

                //老版系统
                if (dtoNew.ProductType == (int)ProductType.Old)
                {
                    isCompany = productAll.FirstOrDefault(o => o.ProductCode.ParseToInt() == corpMemoryDto.ProductId)?.OrganizeType.ParseToInt() == (int)OrganizeType.企业;
                    //老版系统，来自企业产品，切换项目或企业，调整为登录企业。
                    if (isCompany && corpMemoryDto.IsNotNull())
                    {
                        var tempCorpMemoryDto = corpMemoryDto.Adapt<CorpMemoryDto>();
                        corpMemoryDto = corpAll.FirstOrDefault(o => o.CoId == corpMemoryDto.RootCoId && o.CoType == 0);
                        if (corpMemoryDto.IsNotNull())
                        {
                            corpMemoryDto.ProductId = dtoNew.FromProductId > 0 ? dtoNew.FromProductId : dtoNew.ToProductId > 0 ? dtoNew.ToProductId : tempCorpMemoryDto.ProductId;
                            corpMemoryDto.OrganizeType = (int)OrganizeType.企业;
                        }
                    }
                }
            }

            //切换项目或企业
            else if (dtoNew.SwitchType == 1)
            {
                canLoginCorpList = sonCorpList.Where(o => loginProductIds.Contains(o.ProductId)).ToList();
                if (canLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "切换项目或企业无权限！");

                //老版系统
                if (dtoNew.ProductType == (int)ProductType.Old)
                {
                    isCompany = productAll.FirstOrDefault(o => o.ProductCode.ParseToInt() == (dtoNew.FromProductId > 0 ? dtoNew.FromProductId : dtoNew.ToProductId))?.OrganizeType.ParseToInt() == (int)OrganizeType.企业;
                    var tempLoginCorpList = canLoginCorpList.Where(o => dtoNew.ProductType == (int)ProductType.Old ? o.ItemPath.Split(",").Select(int.Parse).Contains(dtoNew.CoId) : o.CoId == dtoNew.CoId).ToList();
                    if (tempLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "切换企业或项目无权限！");
                    corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.ProductId == dtoNew.User.ProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.ProductId == dtoNew.ToProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.ProductId == dtoNew.User.ProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.CoType == 0 && o.ProductId == dtoNew.ToProductId);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.CoType > 0);
                    if (corpMemoryDto.IsNull())
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.CoType == 0);

                    if (dtoNew.ProductType == (int)ProductType.Old && corpMemoryDto.IsNotNull() && corpMemoryDto.CoType == 0)
                    {
                        var tempRootCoId = corpMemoryDto.CoId;
                        tempLoginCorpList = canLoginCorpList.Where(o => o.ItemPath.Split(",").Select(int.Parse).Contains(tempRootCoId) && o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目).ToList();
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.User.ProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.ToProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.FirstOrDefault();
                    }

                    //老版系统，来自企业产品，切换项目或企业，调整为登录企业。
                    if (isCompany && corpMemoryDto.IsNotNull())
                    {
                        var tempCorpMemoryDto = corpMemoryDto.Adapt<CorpMemoryDto>();
                        corpMemoryDto = corpAll.FirstOrDefault(o => o.CoId == corpMemoryDto.RootCoId && o.CoType == 0);
                        if (corpMemoryDto.IsNotNull())
                        {
                            corpMemoryDto.ProductId = dtoNew.FromProductId > 0 ? dtoNew.FromProductId : dtoNew.ToProductId > 0 ? dtoNew.ToProductId : tempCorpMemoryDto.ProductId;
                            corpMemoryDto.OrganizeType = (int)OrganizeType.企业;
                        }
                    }
                }

                //新版系统
                else if (dtoNew.ProductType == (int)ProductType.New)
                {
                    isCompany = canLoginCorpList.Any(o => o.CoId == dtoNew.CoId && o.CoType == 0);
                    //企业
                    if (isCompany)
                    {
                        canLoginCorpList = canLoginCorpList.Where(o => o.CoId == dtoNew.CoId && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业).ToList();
                        if (canLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "切换企业无权限！");
                        corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.User.ProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.ToProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.FirstOrDefault();
                    }

                    //项目
                    else
                    {
                        canLoginCorpList = canLoginCorpList.Where(o => o.CoId == dtoNew.CoId && o.ProId.IsNotEmpty() && o.CoType > 0 && o.OrganizeType == (int)OrganizeType.项目).ToList();
                        if (canLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "切换项目无权限！");
                        corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.User.ProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProductId == dtoNew.ToProductId);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.FirstOrDefault();
                    }
                }
            }

            //切换产品
            else if (dtoNew.SwitchType == 2)
            {
                canLoginCorpList = sonCorpList.Where(o => o.ProductId == dtoNew.ToProductId).ToList();
                if (canLoginCorpList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "切换产品无权限！");

                isCompany = productAll.FirstOrDefault(o => o.ProductCode.ParseToInt() == dtoNew.ToProductId)?.OrganizeType.ParseToInt() == (int)OrganizeType.企业;
                //老版系统
                if (dtoNew.ProductType == (int)ProductType.Old)
                {
                    //企业    //老版系统，切换为企业产品，调整为登录企业。
                    if (isCompany)
                    {
                        corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoId == dtoNew.User.RootCoId && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.Where(o => o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业).FirstOrDefault();
                    }

                    //项目
                    else
                    {
                        corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.ProId == dtoNew.User.ProId && o.CoType > 0 && o.CoId == dtoNew.CoId);
                        if (corpMemoryDto is null)
                            corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.ProId.IsNotEmpty() && o.ProId == dtoNew.User.ProId && o.CoType > 0);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.CoType > 0 && o.CoId == dtoNew.CoId).FirstOrDefault();
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.CoType > 0).FirstOrDefault();
                        //if (corpMemoryDto.IsNotNull() && corpMemoryDto.OrganizeType == (int)OrganizeType.企业 && corpMemoryDto.CoType > 0)
                        //    ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
                    }
                }
                //新版系统
                else if (dtoNew.ProductType == (int)ProductType.New)
                {
                    //企业
                    if (isCompany)
                    {
                        corpMemoryDto = canLoginCorpList.FirstOrDefault(o => o.CoId == dtoNew.User.RootCoId && o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业);
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = canLoginCorpList.Where(o => o.CoType == 0 && o.OrganizeType == (int)OrganizeType.企业).FirstOrDefault();
                    }

                    //项目
                    else
                    {
                        var tempLoginCorpList = canLoginCorpList.Where(o => o.ProId.IsNotEmpty() && o.CoType > 0).ToList();
                        corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProId == dtoNew.User.ProId && o.OrganizeType == (int)OrganizeType.项目);
                        if (corpMemoryDto.IsNull())
                        {
                            corpMemoryDto = tempLoginCorpList.FirstOrDefault(o => o.ProId == dtoNew.User.ProId && o.OrganizeType == (int)OrganizeType.企业);
                            if (corpMemoryDto.IsNotNull()) ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
                        }
                        if (corpMemoryDto.IsNull())
                            corpMemoryDto = tempLoginCorpList.Where(o => o.OrganizeType == (int)OrganizeType.项目).FirstOrDefault();
                        if (corpMemoryDto.IsNull())
                        {
                            corpMemoryDto = tempLoginCorpList.Where(o => o.OrganizeType == (int)OrganizeType.企业).FirstOrDefault();
                            if (corpMemoryDto.IsNotNull()) ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
                        }
                    }
                }
            }

            if (corpMemoryDto.IsNull()) throw new CustomException(ResultCode.LOGIN_ERROR, $"{(dtoNew.SwitchType == 0 ? "登录项目或企业" : dtoNew.SwitchType == 1 ? "切换项目或企业" : "切换产品")}产品异常！");

            //获取登录项目或企业的父级项目或企业

            if (rootCorp.IsNull())
            {
                rootCoId = corpMemoryDto.ItemPath.Split(",").Select(int.Parse).First(o => o > 0);
                rootCorp = jCCorporationService.GetFirst(o => o.CoId == rootCoId);
            }
            if ((corpMemoryDto.CoType == 0 && productAll.FirstOrDefault(o => o.ProductCode == Convert.ToString(corpMemoryDto.ProductId)).OrganizeType == 2) || (corpMemoryDto.CoType > 0 && productAll.FirstOrDefault(o => o.ProductCode == Convert.ToString(corpMemoryDto.ProductId)).OrganizeType == 1))
                ChangeProductOrProject(ChangeProductProjectType.ChangeCorpByProduct);
            dtoNew.ToProductId = corpMemoryDto.ProductId;
            #endregion

            #region 登录数据打包
            JCProduct toProduct = productAll.FirstOrDefault(o => o.ProductCode.ParseToInt() == dtoNew.ToProductId);
            var dbCorpList = jCCorporationService.GetHomeTree(dtoNew, corpAll, loginUserExtDto.IsAdmin);
            var corpList = dbCorpList.Select(o => new CorpTreeDto()
            {
                CoId = o.CoId,
                ParentCoId = o.ParentCoId.ParseToInt(),
                ProId = o.ProId,
                ItemPath = o.ItemPath,
                CoName = o.CoName,
                CoType = o.CoType.ParseToInt(),
            }).ToList();
            loginUserExtDto.CorpList = corpList.Adapt<List<CorpDto>>();
            loginUserExtDto.CorpTreeList = jCCorporationService.GetHomeDeepTree(corpList);
            loginUserExtDto.CorpSubList = loginUserExtDto.CorpList.Where(o => Convert.ToInt32(o.CoType) > 0 && !string.IsNullOrEmpty(o.ProId) && o.ItemPath.Split(",").Select(int.Parse).Contains(corpMemoryDto.CoId)).Select(o => new CorpSubDto() { ProId = o.ProId, CoName = o.CoName }).ToList();
            loginUserExtDto.ProIds = loginUserExtDto.CorpSubList.Select(o => o.ProId).ToList();


            loginUserExtDto.UserId = dtoNew.UserId;
            loginUserExtDto.UserName = dtoNew.UserName;
            loginUserExtDto.TrueName = dtoNew.User.TrueName;
            loginUserExtDto.ProductId = dtoNew.ToProductId;
            loginUserExtDto.ProductName = toProduct.ProductName;
            loginUserExtDto.ProductType = toProduct.ProductType;
            loginUserExtDto.Url = toProduct.Url;
            loginUserExtDto.IsCompany = corpMemoryDto.CoType == 0;
            loginUserExtDto.CoId = corpMemoryDto.CoId;
            loginUserExtDto.CoName = corpMemoryDto.CoName;
            loginUserExtDto.RootCoId = rootCorp is null ? corpMemoryDto.CoId : rootCorp.CoId;
            loginUserExtDto.RootCoName = rootCorp is null ? corpMemoryDto.CoName : rootCorp.CoName;


            loginUserExtDto.RoleList = jCRoleRepository.SelectUserRoleListByUserIdNew(dtoNew.UserId, dtoNew.ToProductId, corpMemoryDto.ItemPath);
            //if (loginUserExtDto.RoleList.Count == 0) throw new CustomException(ResultCode.LOGIN_ERROR, "该用户无匹配角色！");
            var userPowerCode = GetUserPowerCode(loginUserExtDto.RoleList) ?? string.Empty;
            var powerItemList = GetUserPowerItemList(loginUserExtDto, userPowerCode);
            loginUserExtDto.PowerItemList = powerItemList.Select(o => new PowerItemDto
            {
                ItemId = o.ItemId,
                ParentId = o.ParentId.ParseToInt(),
                ItemValue = o.ItemValue,
                ItemName = o.ItemName,
                ItemPath = o.ItemPath,
                ItemIcon1 = o.ItemIcon1,
                ItemType = o.ItemType.ParseToInt()
            }).ToList();
            //if (loginUserExtDto.PowerItemList.Count <= 1) throw new CustomException(ResultCode.LOGIN_ERROR, "该用户无菜单权限！");
            loginUserExtDto.PowerCodeZip = CommonHelper.LZWCompressStr(userPowerCode.TrimStart('0'));

            if (dtoNew.ProductType == (int)ProductType.New)
            {
                var sysMenuList = jCPowerItemService.GetPowerItemTreeData(powerItemList.Where(o => new int?[] { 1, 5 }.Contains(o.ItemType)).ToList());
                if (sysMenuList.Count == 0)
                    throw new CustomException(ResultCode.LOGIN_ERROR, "该用户无路由菜单权限！");
                loginUserExtDto.MenuRouterList = sysMenuList;
            }

            var getProductIds = jCCorporationService.GetHomeParentTree(dtoNew.UserId, corpMemoryDto.ItemPath).Select(o => o.ProductId).Distinct();
            loginUserExtDto.ProductList = productAll.Where(o => getProductIds.Contains(o.ProductCode.ParseToInt())).Select(o => new ProductDto() { ProductCode = o.ProductCode, ProductName = o.ProductName, ProductType = o.ProductType, Url = o.Url }).ToList();
            #endregion

            #region 修改用户最后登录信息
            dtoNew.User.LastLoginIPPre = dtoNew.User.LastLoginIPNow;
            dtoNew.User.LastLoginIPNow = dtoNew.LoginIp;
            dtoNew.User.LastLoginTimePre = dtoNew.User.LastLoginTimeNow;
            dtoNew.User.LastLoginTimeNow = DateTime.Now;
            dtoNew.User.ProductId = corpMemoryDto.ProductId;
            dtoNew.User.RootCoId = corpMemoryDto.CoType == 2 ? corpMemoryDto.CoId : corpMemoryDto.RootCoId;
            if (corpMemoryDto.CoType > 0)
                dtoNew.User.ProId = corpMemoryDto.ProId;
            else
            {
                if (loginUserExtDto.ProIds.Count > 0 && !loginUserExtDto.ProIds.Contains(dtoNew.User.ProId ?? string.Empty))
                    dtoNew.User.ProId = loginUserExtDto.ProIds.First();
            }
            jCUserRepository.Update(dtoNew.User, o => new { o.ProId, o.RootCoId, o.LastLoginIPPre, o.LastLoginIPNow, o.LastLoginTimePre, o.LastLoginTimeNow, o.ProductId }, o => o.UserId == dtoNew.UserId);

            #endregion

            #region 按登录企业或项目切换对应产品
            //1,根据产品换项目，2，根据项目换产品
            void ChangeProductOrProject(ChangeProductProjectType changeProductProjectType)
            {
                if (changeProductProjectType == ChangeProductProjectType.ChangeCorpByProduct)
                {
                    if (corpMemoryDto.CoType == 0)
                    {
                        CorpMemoryDto subCorp = default;
                        if (dtoNew.ProductType == (int)ProductType.Old)
                            subCorp = canLoginCorpList.FirstOrDefault(o => o.RootCoId == corpMemoryDto.CoId && o.OrganizeType == (int)OrganizeType.企业);
                        else if (dtoNew.ProductType == (int)ProductType.New)
                            subCorp = canLoginCorpList.FirstOrDefault(o => o.RootCoId == corpMemoryDto.CoId && o.OrganizeType == (int)OrganizeType.项目);
                        if (subCorp.IsNotNull())
                        {
                            corpMemoryDto.RootCoId = subCorp.RootCoId;
                            corpMemoryDto.CoId = subCorp.CoId;
                            corpMemoryDto.ParentCoId = subCorp.ParentCoId;
                            corpMemoryDto.CoType = subCorp.CoType;
                            corpMemoryDto.CoName = subCorp.CoName;
                            corpMemoryDto.ItemPath = subCorp.ItemPath;
                            corpMemoryDto.ProId = subCorp.ProId;
                        }
                    }
                    else if (corpMemoryDto.CoType > 0)
                    {
                        rootCoId = corpMemoryDto.ItemPath.Split(",").Select(int.Parse).First(o => o > 0);
                        rootCorp = jCCorporationService.GetFirst(o => o.CoId == rootCoId);
                        corpMemoryDto.RootCoId = rootCorp.RootCoId.ParseToInt();
                        corpMemoryDto.CoId = rootCorp.CoId;
                        corpMemoryDto.ParentCoId = rootCorp.ParentCoId.ParseToInt();
                        corpMemoryDto.CoType = rootCorp.CoType.ParseToInt();
                        corpMemoryDto.CoName = rootCorp.CoName;
                        corpMemoryDto.ItemPath = rootCorp.ItemPath;
                        corpMemoryDto.ProId = rootCorp.ProId;
                    }
                }
                if (changeProductProjectType == ChangeProductProjectType.ChangeProductByCorp)
                {
                    var productDto = productAll.FirstOrDefault(o => o.ProductCode.ParseToInt() == corpMemoryDto.ProductId);
                    switch (productDto.ProductCode.ParseToInt())
                    {
                        case GlobalConstant.MaterialByPro:
                        case GlobalConstant.MaterialByCor:
                            if (corpMemoryDto.CoType == 0)
                                corpMemoryDto.ProductId = GlobalConstant.MaterialByCor;
                            else
                                corpMemoryDto.ProductId = GlobalConstant.MaterialByPro;
                            break;
                        case 3:
                        case 9:
                            if (corpMemoryDto.CoType == 0)
                                corpMemoryDto.ProductId = 9;
                            else
                                corpMemoryDto.ProductId = 3;
                            break;
                        case 2:
                        case 4:
                            if (corpMemoryDto.CoType == 0)
                                corpMemoryDto.ProductId = 4;
                            else
                                corpMemoryDto.ProductId = 2;
                            break;
                    }
                }
            }
            #endregion
        }

        public List<JCPowerItem> GetUserPowerItemList(LoginUserExtDto loginUserExtDto, string userPowerCode)
        {
            return Context.Ado.SqlQuery<JCPowerItem>($@"
                SELECT 
                       ItemId,
                       ItemName,
                       ParentId,
                       ItemPath,
                       OrderId,
                       ItemUrlLike,
                       ItemValue,
                       DeleteStatus,
                       ItemIcon1,
                       ItemIcon2,
                       ItemType
                FROM dbo.JC_PowerItem
                WHERE ProductId ={loginUserExtDto.ProductId} 
                AND substring('{userPowerCode}',charindex('1',PowerCode),1) = '1'") ?? new List<JCPowerItem>();
        }

        /// <summary>
        /// 根据角色获取权限码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private string GetUserPowerCode(List<string> roleList)
        {
            if (roleList is null || roleList.Count == 0) return default;
            char[] newcode = default;
            foreach (var item in roleList)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (newcode == null)
                {
                    newcode = "0".PadLeft(item.Length, '0').ToCharArray();
                }
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '1')
                        newcode[i] = '1';
                }
            }
            return new string(newcode);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="loginBody"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, SysLogininfor logininfor)
        {
            //密码md5
            loginBody.Password = NETCore.Encrypt.EncryptProvider.Md5(loginBody.Password);

            SysUser user = SysUserRepository.Login(loginBody);
            logininfor.UserName = loginBody.Username;
            logininfor.Status = "1";
            logininfor.LoginTime = DateTime.Now;

            if (user == null || user.UserId <= 0)
            {
                logininfor.Msg = "用户名或密码错误";
                AddLoginInfo(logininfor);
                throw new CustomException(ResultCode.LOGIN_ERROR, logininfor.Msg);
            }
            if (user.Status == "1")
            {
                logininfor.Msg = "该用户已禁用";
                AddLoginInfo(logininfor);
                throw new CustomException(ResultCode.LOGIN_ERROR, logininfor.Msg);
            }

            logininfor.Status = "0";
            logininfor.Msg = "登录成功";
            AddLoginInfo(logininfor);
            SysUserRepository.UpdateLoginInfo(loginBody, user.UserId);
            return user;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<SysLogininfor> GetLoginLog(SysLogininfor logininfoDto, PagerInfo pager)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);

            var exp = Expressionable.Create<SysLogininfor>();
            exp.And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);
            exp.AndIF(logininfoDto.Ipaddr.IfNotEmpty(), f => f.Ipaddr == logininfoDto.Ipaddr);
            exp.AndIF(logininfoDto.UserName.IfNotEmpty(), f => f.UserName.Contains(logininfoDto.UserName));
            exp.AndIF(logininfoDto.Status.IfNotEmpty(), f => f.Status == logininfoDto.Status);
            var query = Queryable().Where(exp.ToExpression())
                .OrderBy(it => it.InfoId, OrderByType.Desc);

            return query.ToPage(pager);
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="sysLogininfor"></param>
        /// <returns></returns>
        public void AddLoginInfo(SysLogininfor sysLogininfor, string error = default)
        {
            if (!error.IsEmpty()) sysLogininfor.Msg = error;
            Insert(sysLogininfor);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogininfo()
        {
            Truncate();
        }

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteLogininforByIds(long[] ids)
        {
            return Delete(ids);
        }
    }
}
