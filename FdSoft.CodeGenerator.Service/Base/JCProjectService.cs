using System;
using SqlSugar;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Repository;
using FdSoft.CodeGenerator.Service.Base.IBaseService;

namespace FdSoft.CodeGenerator.Service.Base
{
    /// <summary>
    /// 项目信息Service业务层处理
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [AppService(ServiceType = typeof(IJCProjectService), ServiceLifetime = LifeTime.Transient)]
    public class JCProjectService : BaseService<JCProject>, IJCProjectService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询项目信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<JCProject> GetList(JCProjectQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<JCProject>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddJCProject(JCProject parm)
        {
            var response = Insert(parm, it => new
            {
                it.ProId,
                it.ProNo,
                it.ProName,
                it.ProSmallName,
                it.Status,
                it.ActiveStatus,
                it.Progress,
                it.ProSubType,
                it.ProType,
                it.AreaCode,
                it.TenderNum,
                it.RegNumber,
                it.RegDate,
                it.ProAddress,
                it.ShigongCerNo,
                it.ProPrice,
                it.ProSalaryCost,
                it.BeginDate,
                it.EndDate,
                it.ProjectHeight,
                it.ProjectFloor,
                it.ProjectFloorInfo,
                it.ProjectArea,
                it.ProjectAreaInfo,
                it.ProjectStruct,
                it.Bank,
                it.MapPos,
                it.SyncType,
                it.ShigongUnitCorpCode,
                it.ShigongUnitName,
                it.JianLiUnitCorpCode,
                it.JianLiUnitName,
                it.ConsUnitCorpCode,
                it.ConsUnitName,
                it.DesignUnitCorpCode,
                it.DesignUnitName,
                it.KanchaUnitCorpCode,
                it.KanchaUnitName,
                it.ProManager,
                it.JsonData,
                it.AuthStatus,
                it.AuthEndDate,
                it.CreateUserId,
                it.LastEditUserId,
                it.LastEditor,
                it.Creator,
                it.DeleteStatus,
                it.AddTime,
                it.UpdateTime,
                it.ProjectCode,
                it.ExtPK1,
                it.HideStatus,
            });
            return response;
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateJCProject(JCProject parm)
        {
            var response = Update(w => w.ProId == parm.ProId, it => new JCProject()
            {
                ProNo = parm.ProNo,
                ProName = parm.ProName,
                ProSmallName = parm.ProSmallName,
                Status = parm.Status,
                ActiveStatus = parm.ActiveStatus,
                Progress = parm.Progress,
                ProSubType = parm.ProSubType,
                ProType = parm.ProType,
                AreaCode = parm.AreaCode,
                TenderNum = parm.TenderNum,
                RegNumber = parm.RegNumber,
                RegDate = parm.RegDate,
                ProAddress = parm.ProAddress,
                ShigongCerNo = parm.ShigongCerNo,
                ProPrice = parm.ProPrice,
                ProSalaryCost = parm.ProSalaryCost,
                BeginDate = parm.BeginDate,
                EndDate = parm.EndDate,
                ProjectHeight = parm.ProjectHeight,
                ProjectFloor = parm.ProjectFloor,
                ProjectFloorInfo = parm.ProjectFloorInfo,
                ProjectArea = parm.ProjectArea,
                ProjectAreaInfo = parm.ProjectAreaInfo,
                ProjectStruct = parm.ProjectStruct,
                Bank = parm.Bank,
                MapPos = parm.MapPos,
                SyncType = parm.SyncType,
                ShigongUnitCorpCode = parm.ShigongUnitCorpCode,
                ShigongUnitName = parm.ShigongUnitName,
                JianLiUnitCorpCode = parm.JianLiUnitCorpCode,
                JianLiUnitName = parm.JianLiUnitName,
                ConsUnitCorpCode = parm.ConsUnitCorpCode,
                ConsUnitName = parm.ConsUnitName,
                DesignUnitCorpCode = parm.DesignUnitCorpCode,
                DesignUnitName = parm.DesignUnitName,
                KanchaUnitCorpCode = parm.KanchaUnitCorpCode,
                KanchaUnitName = parm.KanchaUnitName,
                ProManager = parm.ProManager,
                JsonData = parm.JsonData,
                AuthStatus = parm.AuthStatus,
                AuthEndDate = parm.AuthEndDate,
                CreateUserId = parm.CreateUserId,
                LastEditUserId = parm.LastEditUserId,
                LastEditor = parm.LastEditor,
                Creator = parm.Creator,
                DeleteStatus = parm.DeleteStatus,
                AddTime = parm.AddTime,
                UpdateTime = parm.UpdateTime,
                ProjectCode = parm.ProjectCode,
                ExtPK1 = parm.ExtPK1,
            });
            return response;
        }

        /// <summary>
        /// 清空项目信息
        /// </summary>
        /// <returns></returns>
        public void TruncateJCProject()
        {
            Truncate();
        }
        #endregion
    }
}