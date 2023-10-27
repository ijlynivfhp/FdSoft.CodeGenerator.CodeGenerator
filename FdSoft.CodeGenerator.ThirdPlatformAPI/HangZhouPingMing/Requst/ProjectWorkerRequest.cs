using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst
{
    /// <summary>
    /// 查询项目工人信息请求
    /// </summary>
    public class ProjectWorkerRequest : BaseRequest
    {
        /// <summary>
        /// 班组编号
        /// </summary>
        public int? teamSysNo { get; set; }
        /// <summary>
        /// 证件类型，参考人员证件类型字典表
        /// </summary>
        public string idCardType { get; set; } = "01";
        /// <summary>
        /// 证件号码，AES
        /// </summary>
        public string idCardNumber { get; set; }
    }
}
