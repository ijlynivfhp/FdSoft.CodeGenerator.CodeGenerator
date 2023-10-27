using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetAlarmRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.8 上传安全帽报警数据
    /// </summary>
    public class HelmetAlarmRequest : BaseRequest<HelmetAlarm>
    {
        public class HelmetAlarm
        {
            /// <summary>
            /// 是 报警时间
            /// </summary>
            public DateTime alarmTime { get; set; }
            /// <summary>
            /// int 是 报警类型，参考安全帽预警类型字典表
            /// </summary>
            public HelmetAlarmEnum alarmType { get; set; }
            /// <summary>
            /// 否 抓拍图片地址
            /// </summary>
            public string imageUrl { get; set; }
            /// <summary>
            /// 否 纬度
            /// </summary>
            public decimal latitude { get; set; }
            /// <summary>
            /// 否 经度
            /// </summary>
            public decimal longitude { get; set; }
            /// <summary>
            /// 否 设备名称
            /// </summary>
            public string hardwareName { get; set; }
            /// <summary>
            /// 否 使用人姓名
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 否 使用人手机号
            /// </summary>
            public string userPhone { get; set; }
            /// <summary>
            /// 否 使用人身份证号
            /// </summary>
            public string userIdCard { get; set; }
            /// <summary>
            /// 否 所在班组
            /// </summary>
            public string userTeam { get; set; }
            /// <summary>
            /// 否 工种类型
            /// </summary>
            public string userWorkType { get; set; }
        }
    }
}