using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 项目信息service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCProjectService : IBaseService<JCProject>
    {
        PagedInfo<JCProject> GetList(JCProjectQueryDto parm);

        int AddJCProject(JCProject parm);

        int UpdateJCProject(JCProject parm);
        
        void TruncateJCProject();
    }
}
