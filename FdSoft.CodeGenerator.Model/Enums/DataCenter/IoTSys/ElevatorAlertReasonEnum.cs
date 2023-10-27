using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.DataCenter.IoTSys
{
    /// <summary>
    /// 升降梯预警/报警原因
    /// </summary>
    public enum ElevatorAlertReasonEnum
    {
        重量 = 1,
        /// <summary>
        /// V1有，V2没有
        /// </summary>
        高度 = 2,
        速度 = 3,
        人数 = 4,
        X倾斜 = 5,
        /// <summary>
        /// V1没有，V2有
        /// </summary>
        Y倾斜 = 6,
        风速 = 7,
    }
}
