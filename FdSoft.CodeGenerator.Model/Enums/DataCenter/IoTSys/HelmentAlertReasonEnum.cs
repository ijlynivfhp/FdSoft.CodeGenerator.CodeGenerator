using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.DataCenter.IoTSys
{
    /// <summary>
    /// 安全帽报警原因
    /// </summary>
    public enum HelmentAlertReasonEnum
    {
        脱帽报警 = 1,
        围栏报警离开工作区域 = 2,
        温度报警,
        跌落撞击报警,
        围栏报警进入禁区,
        静默报警,
        SOS报警,
        近电报警,
        登高报警,
        进入蓝牙信标报警,
        离开蓝牙信标报警,
        氧气报警,
        甲烷报警,
        一氧化碳浓度,
        体温报警,
        心率报警,
        血压报警,
    }
}
