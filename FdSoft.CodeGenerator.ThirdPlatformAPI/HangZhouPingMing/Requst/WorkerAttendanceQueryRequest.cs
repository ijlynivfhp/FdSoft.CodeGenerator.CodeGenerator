using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst
{
    /// <summary>
    /// 查询工人考勤
    /// </summary>
    public class WorkerAttendanceQueryRequest : BaseRequest
    {
        /// <summary>
        ///   考勤日期， 格式 yyyy-MM-dd  必填
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 证件类型， 参考人员证件类型字典表  01身份证
        /// </summary>
        public string? idCardType { get; set; }

        /// <summary>
        /// 证件号码， AES后的
        /// </summary>
        public string? idCardNumber { get; set; }
    }
}
