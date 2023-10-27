using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    /// <summary>
    /// RD_EarlyWarnByWorker表的预警状态
    /// </summary>
    public enum EarlyWarnStatusEnum
    {
        待处理 = 1,
        已处理 = 2,

        已忽略 = 3,
        已退场 = 4,
    }
}
