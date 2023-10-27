using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi.Model
{
    public class FaceDeviceConfigDTO
    {
        public string appId { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string deviceNo { get; set; }

        /// <summary>
        /// 健康码城市编码
        /// </summary>
        public string cityNo { get; set; }

        /// <summary>
        /// 健康码授权密钥
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// 健康码是否启用 1.开启 2.关闭
        /// </summary>
        public int? IsHealthCodeOpen { get; set; }
    }
}
