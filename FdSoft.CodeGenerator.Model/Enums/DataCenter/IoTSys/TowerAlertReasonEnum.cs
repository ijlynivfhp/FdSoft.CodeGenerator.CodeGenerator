using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.DataCenter.IoTSys
{
    /// <summary>
    /// 塔吊预警/报警原因
    /// </summary>
    public enum TowerAlertReasonEnum
    {
        重量 = 1,
        力矩 = 2,
        X倾斜 = 3,
        Y倾斜 = 4,
        风速 = 5,
        碰撞 = 6,
        幅度 = 7,
        高度 = 8,
        回转 = 9,
    }
}
