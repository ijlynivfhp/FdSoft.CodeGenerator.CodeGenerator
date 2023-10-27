using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 用户角色关联表service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCUserRoleService : IBaseService<JCUserRole>
    {
        PagedInfo<JCUserRole> GetList(JCUserRoleQueryDto parm);

        int AddJCUserRole(JCUserRole parm);

        int UpdateJCUserRole(JCUserRole parm);
        
        void TruncateJCUserRole();
    }
}
