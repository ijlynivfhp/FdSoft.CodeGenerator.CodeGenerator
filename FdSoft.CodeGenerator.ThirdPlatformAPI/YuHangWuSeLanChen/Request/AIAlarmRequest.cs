using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.AIAlarmRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.6 上传塔吊告警数据
    /// </summary>
    public class AIAlarmRequest : BaseRequest<AIAlarm>
    {
        public class AIAlarm
        {
            /// <summary>
            /// 是 事件类型，参考AI分析告警事件字典表
            /// </summary>
            public int eventType { get; set; }
            /// <summary>
            /// 是 报警时间戳，单位：毫秒
            /// </summary>
            public long alarmEndTime { get; set; }
            /// <summary>
            /// 是 抓拍图片地址
            /// </summary>
            public string imageUrl { get; set; }
        }
    }
}