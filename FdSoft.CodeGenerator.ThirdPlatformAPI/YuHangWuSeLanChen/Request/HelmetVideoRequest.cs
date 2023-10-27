using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetVideoRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    public class HelmetVideoRequest : BaseRequest<HelmetVideo>
    {
        public class HelmetVideo
        {
            /// <summary>
            /// 视频流地址，m3u8格式
            /// </summary>
            public string videoUrl { get; set; }
        }
    }
}
