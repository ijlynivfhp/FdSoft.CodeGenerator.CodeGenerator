using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.DataCenter.IoTSys
{
    /// <summary>
    /// Iot设备刷脸考勤人员身份类型
    /// </summary>
    public enum DriverTypeEnum
    {
        未知人员 = 0,
        塔机司机 = 1,
        检测人员 = 2,
        安拆人员 = 3,
        维保人员 = 4,
        塔机信号工 = 5,
        监理人员 = 6,
        项目经理 = 7,
        安全员 = 8,
    }
}
