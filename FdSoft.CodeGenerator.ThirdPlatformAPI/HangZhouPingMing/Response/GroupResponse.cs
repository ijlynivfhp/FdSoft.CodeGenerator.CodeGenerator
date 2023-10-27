using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.GroupResponse;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response
{
    /// <summary>
    /// 查询班组信息响应
    /// </summary>
    public class GroupResponse:BaseResponse<GroupRow>
    {
        /// <summary>
        /// 查询班组信息
        /// </summary>
        public class GroupRow {
            /// <summary>
            /// 班组编号
            /// </summary>
            public int teamSysNo { get; set; }
            /// <summary>
            /// 项目编码
            /// </summary>
            public string projectCode { get; set; }
            /// <summary>
            /// 班组所在企业统一社会信用代码， 如果无统一社会信用代码，则用组织机构代码
            /// </summary>
            public string corpCode { get; set; }
            /// <summary>
            /// 班组所在企业名称
            /// </summary>
            public string corpName { get; set; }
            /// <summary>
            /// 班组名称，同一个项目和参建单位下面不能重复
            /// </summary>
            public string teamName { get; set; }
            /// <summary>
            /// 班组长姓名
            /// </summary>
            public string teamLeaderName { get; set; }
            /// <summary>
            /// 班级长联系方式
            /// </summary>
            public string teamLeaderPhone { get; set; }
            /// <summary>
            /// 班组长证件类型。参考人员证件类型字典表
            /// </summary>
            public string teamLeaderIDCardType { get; set; }
            /// <summary>
            /// 班组长证件号码，AES
            /// </summary>
            public string teamLeaderIDNumber { get; set; }
            /// <summary>
            /// 责任人姓名，班组所在企业负责人
            /// </summary>
            public string responsiblePersonName { get; set; }
            /// <summary>
            /// 责任人联系电话
            /// </summary>
            public string responsiblePersonPhone { get; set; }
            /// <summary>
            /// 责任人证件类型。
            /// </summary>
            public string responsiblePersonIDCardType { get; set; }
            /// <summary>
            /// 责任人证件号码。AES
            /// </summary>
            public string responsiblePersonIDNumber { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string remark { get; set; }
            /// <summary>
            /// 进场日期，yyyy-MM-dd
            /// </summary>
            public string entryTime { get; set; }
            /// <summary>
            /// 退场日期，yyyy-MM-dd
            /// </summary>
            public string exitTime { get; set; }
            /// <summary>
            /// 进场附件，有进场日期时，此字段必填。JSON 数组。附件总数不超过5 个
            /// </summary>
            public List<Attachment> entryAttachments { get; set; }
            /// <summary>
            /// 退场附件，有退场日期时，此字段必填。JSON 数组。附件总数不超过5 个
            /// </summary>
            public List<Attachment> exitAttachments { get; set; }

            /// <summary>
            /// 附件
            /// </summary>
            public class Attachment
            {
                /// <summary>
                /// 附件名称
                /// </summary>
                public string name { get; set; }
                /// <summary>
                /// 附件 Base64 字符串，不超过 1M
                /// </summary>
                public string data { get; set; }
            }
    }
    }
}
