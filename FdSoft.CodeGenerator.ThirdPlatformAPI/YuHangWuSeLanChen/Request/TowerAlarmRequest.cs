using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerAlarmRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.6 上传塔吊告警数据
    /// </summary>
    public class TowerAlarmRequest : BaseRequest<TowerAlarm>
    {
        public class TowerAlarm
        {
            /// <summary>
            /// 是 报警开始时间
            /// </summary>
            public DateTime alarmStartTime { get; set; }
            /// <summary>
            /// 是 报警结束时间
            /// </summary>
            public DateTime alarmEndTime { get; set; }
            /// <summary>
            /// 是 幅度(m)
            /// </summary>
            public decimal radius { get; set; }
            /// <summary>
            /// 是 吊重(t)
            /// </summary>
            public decimal load { get; set; }
            /// <summary>
            /// 是 回转角度
            /// </summary>
            public decimal angle { get; set; }
            /// <summary>
            /// 是 力矩百分比(%)
            /// </summary>
            public decimal momentPer { get; set; }
            /// <summary>
            /// 是 系统输出控制状态编码
            /// </summary>
            public int controlCode { get; set; }
            /// <summary>
            /// 是 系统预警状态编码，默认传 0
            /// </summary>
            public int preAlarmCode { get; set; }
            /// <summary>
            /// 是 违章操作状态编码，默认传 0
            /// </summary>
            public int breakRuleCode { get; set; }
            /// <summary>
            /// 是 传感器报警状态编码，默认传 0
            /// </summary>
            public int sensorAlarmCode { get; set; }
            /// <summary>
            /// 是 系统报警状态编码，默认传 0
            /// </summary>
            public int alarmCode { get; set; }
            /// <summary>
            /// 是 预警类型，参考塔吊预警类型字典表
            /// </summary>
            public TowerAlarmEnum alarmItem { get; set; }
        }
    }
}