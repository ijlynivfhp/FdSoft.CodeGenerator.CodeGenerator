using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst
{
    /// <summary>
    /// 进出场历史记录查询请求
    /// </summary>
    public class WorkerEntryExitQueryRequest: BaseRequest
    {
        /// <summary>
        /// 进出场日期   查询某一天的进出场记录，注意：文档中没有标注有该参数，而且格式必须是yyyy-MM-dd，不能有时分秒部分
        /// </summary>
        public string entryExitDate { get; set; }

        /// <summary>
        ///班组编号
        /// </summary>
        public int? teamSysNo { get; set; }

        /// <summary>
        /// 证件类型，参考人员证件类型字典 表   (01 居民身份证)
        /// </summary>
        public string? idCardType { get; set; }

        /// <summary>
        /// 证件号码，AES
        /// </summary>
        public string? idCardNumber { get; set; }
    }
}
