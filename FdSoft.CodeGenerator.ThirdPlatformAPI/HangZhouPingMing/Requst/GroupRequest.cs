using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst
{
    /// <summary>
    /// 查询班组信息请求
    /// </summary>
    public class GroupRequest : BaseRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 班组编号
        /// </summary>
        public int? teamSysNo { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string teamName { get; set; }
    }
}
