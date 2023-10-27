using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    /// <summary>
    /// 劳务数据同步结果状态
    /// </summary>
    public enum SyncResultStatusEnum
    {
        失败 = -1,
        待同步,
        同步中,
        已同步,
    }
}
