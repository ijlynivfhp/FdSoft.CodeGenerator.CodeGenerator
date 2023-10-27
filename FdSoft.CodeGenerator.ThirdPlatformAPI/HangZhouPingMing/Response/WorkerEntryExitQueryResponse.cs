using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response
{
    /// <summary>
    /// 进退场记录响应数据
    /// </summary>
    public class WorkerEntryExitQueryResponse: BaseResponse<WorkerEntryExitQueryResponseRow>
    {

    }

    /// <summary>
    /// 进退场记录响应数据
    /// </summary>
    public class WorkerEntryExitQueryResponseRow
    {
        /// <summary>
        /// 工人所在企业统一社会信用代码， 如果无统一社会信用代码，则用组 织机构代码
        /// </summary>
        public string corpCode { get; set; }

        /// <summary>
        /// 工人所在企业名称
        /// </summary>
        public string corpName { get; set; }

        /// <summary>
        /// 进退场日期,yyyy-MM-dd
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 进退场时间
        /// </summary>
        public string dateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long entryExitId { get; set; }

        /// <summary>
        /// 证件号码。AES编码过的身份证号
        /// </summary>
        public string idCardNumber { get; set; }

        /// <summary>
        /// 证件类型。参考人员证件类型字典表  01身份证
        /// </summary>
        public string idCardType { get; set; }

        /// <summary>
        /// 项目编码
        /// </summary>
        public string projectCode { get; set; }

        /// <summary>
        /// 班组编号
        /// </summary>
        public int teamSysNo { get; set; }

        /// <summary>
        /// 类型。参考工人进退场类型字典表  0退场 1进场
        /// </summary>
        public int type { get; set; }

    }


}
