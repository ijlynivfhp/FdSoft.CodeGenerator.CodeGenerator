using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 企业项目用户关联信息service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCUserCorporationService : IBaseService<JCUserCorporation>
    {
        PagedInfo<JCUserCorporation> GetList(JCUserCorporationQueryDto parm);

        int AddJCUserCorporation(JCUserCorporation parm);

        int UpdateJCUserCorporation(JCUserCorporation parm);
        
        void TruncateJCUserCorporation();
    }
}
