using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Model.Dto.Base;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 角色信息service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCRoleService : IBaseService<JCRole>
    {
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> SelectUserRoleListByUserIdNew(int userId, int productId, string itemPath);

        PagedInfo<JCRole> GetList(JCRoleQueryDto parm);

        int AddJCRole(JCRole parm);

        int UpdateJCRole(JCRole parm);
        
        void TruncateJCRole();
    }
}
