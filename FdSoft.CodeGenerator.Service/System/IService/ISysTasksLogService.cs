using System.Threading.Tasks;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Repository;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    public interface ISysTasksLogService : IBaseService<SysTasksLog>
    {
        /// <summary>
        /// 记录任务执行日志
        /// </summary>
        /// <returns></returns>
        //public int AddTaskLog(string jobId);
        Task<SysTasksLog> AddTaskLog(string jobId, SysTasksLog tasksLog);
    }
}
