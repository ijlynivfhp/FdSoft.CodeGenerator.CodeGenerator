using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using System.Collections.Generic;
using System.Data;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 用户表Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCUserService), ServiceLifetime = LifeTime.Transient)]
    public class JCUserService : BaseService<JCUser>, IJCUserService
    {

        #region 扩展业务代码

        #endregion
        #region 业务逻辑代码

        /// <summary>
        /// 查询用户表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCUser> GetList(JCUserQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCUser>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加用户表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCUser(JCUser parm)
        {
            var response = Insert(parm, it => new
            {
                it.UserName,
                it.UserPwd,
                it.TrueName,
                it.Status,
                it.Sex,
                it.IDCard,
                it.Email,
                it.TelePhone,
                it.CertNo,
                it.TelePhoneVerifyStatus,
                it.LastLoginTimeNow,
                it.LastLoginTimePre,
                it.LastLoginIPNow,
                it.LastLoginIPPre,
                it.LoginCount,
                it.RootCoId,
                it.ProId,
                it.ProductId,
                it.RoleId,
                it.CreateUserId,
                it.LastEditUserId,
                it.Creator,
                it.LastEditor,
                it.DeleteStatus,
                it.AddTime,
                it.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改用户表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCUser(JCUser parm)
        {
            var response = Update(w => w.UserId == parm.UserId, it => new JCUser()
            {
                UserName = parm.UserName,
                UserPwd = parm.UserPwd,
                TrueName = parm.TrueName,
                Status = parm.Status,
                Sex = parm.Sex,
                IDCard = parm.IDCard,
                Email = parm.Email,
                TelePhone = parm.TelePhone,
                CertNo = parm.CertNo,
                TelePhoneVerifyStatus = parm.TelePhoneVerifyStatus,
                LastLoginTimeNow = parm.LastLoginTimeNow,
                LastLoginTimePre = parm.LastLoginTimePre,
                LastLoginIPNow = parm.LastLoginIPNow,
                LastLoginIPPre = parm.LastLoginIPPre,
                LoginCount = parm.LoginCount,
                RootCoId = parm.RootCoId,
                ProId = parm.ProId,
                ProductId = parm.ProductId,
                RoleId = parm.RoleId,
                CreateUserId = parm.CreateUserId,
                LastEditUserId = parm.LastEditUserId,
                Creator = parm.Creator,
                LastEditor = parm.LastEditor,
                DeleteStatus = parm.DeleteStatus,
                AddTime = parm.AddTime,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空用户表
        /// </summary>
        /// <returns></returns>
        public void TruncateJCUser()
        {
            Truncate();
        }
        #endregion
    }
}