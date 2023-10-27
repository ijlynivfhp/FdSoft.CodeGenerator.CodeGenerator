using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    /// <summary>
    /// Labor_ProjectWorker表的进退场状态
    /// </summary>
    public enum ProjectWorkerJoinStatusEnum
    {
        退场 = 0,
        入场 = 1
    }

    /// <summary>
    /// Labor_ProjectWorkerJoinQuitHistory表的进退场状态
    /// </summary>
    public enum JoinQuitHistoryInOutTypeEnum
    {
        进 = 1,
        出 = 2,
    }
}
