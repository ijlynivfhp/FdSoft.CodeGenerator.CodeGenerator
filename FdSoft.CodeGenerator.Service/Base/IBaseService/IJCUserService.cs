using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 用户表service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCUserService : IBaseService<JCUser>
    {
        PagedInfo<JCUser> GetList(JCUserQueryDto parm);

        int AddJCUser(JCUser parm);

        int UpdateJCUser(JCUser parm);
        
        void TruncateJCUser();
    }
}
