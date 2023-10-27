using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Model.System.Dto;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface ISysTasksQzService : IBaseService<SysTasksQz>
    {
        //SysTasksQz GetId(object id);
        int AddTasks(SysTasksQz parm);
        int UpdateTasks(SysTasksQz parm);
    }
}
