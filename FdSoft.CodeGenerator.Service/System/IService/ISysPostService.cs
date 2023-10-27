using System;
using System.Collections.Generic;
using System.Text;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Repository;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);
        string CheckPostCodeUnique(SysPost sysPost);
        List<SysPost> GetAll();
    }
}
