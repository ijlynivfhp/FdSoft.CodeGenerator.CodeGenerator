using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);
        public List<string> GetMenuPermission(SysUser user);
    }
}
