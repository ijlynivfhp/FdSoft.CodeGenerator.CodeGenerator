using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetTrackRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.9 上传安全帽定位数据
    /// </summary>
    public class HelmetTrackRequest : BaseRequest<HelmetTrack>
    {
        public class HelmetTrack
        {
            /// <summary>
            /// date 是 定位时间
            /// </summary>
            public DateTime locationTime { get; set; }
            /// <summary>
            /// 是 纬度
            /// </summary>
            public decimal latitude { get; set; }
            /// <summary>
            /// 是 经度
            /// </summary>
            public decimal longitude { get; set; }
        }
    }
}