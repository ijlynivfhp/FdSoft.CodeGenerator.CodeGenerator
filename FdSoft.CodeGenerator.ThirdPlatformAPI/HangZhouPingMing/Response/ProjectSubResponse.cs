using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.ProjectSubResponse;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response
{
    /// <summary>
    /// 查询项目参建单位信息响应
    /// </summary>
    public class ProjectSubResponse : BaseResponse<ProjectSubRow>
    {
        /// <summary>
        /// 2.1.2查询项目参建单位信息
        /// </summary>
        public class ProjectSubRow
        {
            /// <summary>
            /// 项目编码
            /// </summary>
            public string projectCode { get; set; }
            /// <summary>
            /// 统一社会信用代码，如果无统一社会信用代码，则用组织机构代码
            /// </summary>
            public string corpCode { get; set; }
            /// <summary>
            /// 企业名称
            /// </summary>
            public string corpName { get; set; }
            /// <summary>
            /// 参建类型。参考参建单位类型字典表
            /// </summary>
            public string corpType { get; set; }
            /// <summary>
            /// 进场时间。格式 yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string entryTime { get; set; }
            /// <summary>
            /// 退场时间。格式 yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string exitTime { get; set; }
            /// <summary>
            /// 发放工资的银行。JSON 数组
            /// </summary>
            public List<BankInfo> bankInfos { get; set; }
            /// <summary>
            /// 项目经理名称
            /// </summary>
            public string pmName { get; set; }
            /// <summary>
            /// 项目经理证件类型。参考人员证件类型字典表
            /// </summary>
            public string pmIDCardType { get; set; }
            /// <summary>
            /// 项目经理证件号码。AES
            /// </summary>
            public string pmIDCardNumber { get; set; }
            /// <summary>
            /// 项目经理电话
            /// </summary>
            public string pmPhone { get; set; }

            /// <summary>
            /// 发放工资的银行
            /// </summary>
            public class BankInfo {
                /// <summary>
                /// 银行代码。
                /// </summary>
                public string bankCode { get; set; }
                /// <summary>
                /// 银行支行名称
                /// </summary>
                public string bankName { get; set; }
                /// <summary>
                /// 银行卡号。AES
                /// </summary>
                public string bankNumber { get; set; }
                /// <summary>
                /// 银行联号
                /// </summary>
                public string bankLinkNumber { get; set; }
            }
        }
    }
}
