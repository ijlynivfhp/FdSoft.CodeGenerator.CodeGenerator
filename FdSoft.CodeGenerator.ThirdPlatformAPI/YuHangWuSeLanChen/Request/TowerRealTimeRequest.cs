using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerRealTimeRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.5 上传塔吊实时数据
    /// </summary>
    public class TowerRealTimeRequest : BaseRequest<TowerRealTime>
    {
        public class TowerRealTime
        {
            /// <summary>
            /// long 是 表示当前发送数据的序号
            /// </summary>
            public long dataIndex { get; set; }
            /// <summary>
            /// date 是 采集时间
            /// </summary>
            public DateTime collectionTime { get; set; }
            /// <summary>
            /// double 是 回转角度
            /// </summary>
            public decimal angle { get; set; }
            /// <summary>
            /// double 是 幅度(m)
            /// </summary>
            public decimal radius { get; set; }
            /// <summary>
            /// double 是 吊钩高度(m)
            /// </summary>
            public decimal height { get; set; }
            /// <summary>
            /// double 是 吊重(t)
            /// </summary>
            public decimal load { get; set; }
            /// <summary>
            /// double 是 安全吊重(t)
            /// </summary>
            public decimal safeLoad { get; set; }
            /// <summary>
            /// double 是 力矩百分比(%)
            /// </summary>
            public decimal momentPer { get; set; }
            /// <summary>
            /// double 是 风速(m/s)
            /// </summary>
            public decimal windSpeed { get; set; }
            /// <summary>
            /// double 是 塔机倾斜角度(°)
            /// </summary>
            public decimal obliquity { get; set; }
            /// <summary>
            /// double 是 塔机方向(°)
            /// </summary>
            public decimal obliquityDirAnge { get; set; }
            /// <summary>
            /// integer 是 吊绳倍率
            /// </summary>
            public int fall { get; set; }
            /// <summary>
            /// integer 是 系统输出控制状态编码
            /// </summary>
            public int controlCode { get; set; }
            /// <summary>
            /// integer 是 系统预警状态编码
            /// </summary>
            public decimal preAlarmCode { get; set; }
            /// <summary>
            /// integer 是 违章操作状态编码
            /// </summary>
            public decimal breakRuleCode { get; set; }
            /// <summary>
            /// integer 是 传感器报警状态编码
            /// </summary>
            public decimal sensorAlarmCode { get; set; }
            /// <summary>
            /// integer 是 系统报警状态编码
            /// </summary>
            public decimal alarmCode { get; set; }
            /// <summary>
            /// string 是 操作员姓名
            /// </summary>
            public string operatorName { get; set; }
        }
    }
}