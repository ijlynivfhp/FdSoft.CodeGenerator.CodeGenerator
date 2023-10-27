using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    public class DeviceStatusRequest : BaseRequest<DeviceStatus>
    {
        public class DeviceStatus
        {
            /// <summary>
            /// 设备状态 0 离线 ，1 在线
            /// </summary>
            public int status { get; set; }
        }
    }
}
