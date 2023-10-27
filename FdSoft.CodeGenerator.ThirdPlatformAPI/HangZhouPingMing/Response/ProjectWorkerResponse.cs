using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.ProjectWorkerResponse;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response
{
    /// <summary>
    /// 查询项目工人信息响应
    /// </summary>
    public class ProjectWorkerResponse:BaseResponse<ProjectWorkerRow>
    {

        /// <summary>
        /// 查询项目工人信息
        /// </summary>
        public class ProjectWorkerRow
        {
            /// <summary>
            /// string 是 项目编码
            /// </summary>
            public string projectCode { get; set; }

            /// <summary>
            /// string 是 工人所在企业统一社会信用代码，如果无统一社会信用代码，则用组织机构代码
            /// </summary>
            public string corpCode { get; set; }

            /// <summary>
            /// string 是 工人所在企业名称
            /// </summary>
            public string corpName { get; set; }

            /// <summary>
            /// string 是 班组名称
            /// </summary>
            public string teamName { get; set; }

            /// <summary>
            /// int 是 班组编号
            /// </summary>
            public int teamSysNo { get; set; }

            /// <summary>
            /// string 是 工人姓名
            /// </summary>
            public string workerName { get; set; }

            /// <summary>
            /// int 是 是否班组长。参考是否字典表
            /// 字典是int，实际接收是bool
            /// </summary>
            public bool isTeamLeader { get; set; }

            /// <summary>
            /// string 是 证件类型。参考人员证件类型字典表
            /// </summary>
            public string idCardType { get; set; }

            /// <summary>
            /// string 是 证件号码。AES
            /// </summary>
            public string idCardNumber { get; set; }

            /// <summary>
            /// string 是 当前工种。参考工人工种字典表
            /// </summary>
            public string workType { get; set; }

            /// <summary>
            /// int 是 工人类型。参考工人类型字典表
            /// </summary>
            public int workRole { get; set; }

            /// <summary>
            /// string 否 进场时间
            /// </summary>
            public DateTime? entryTime { get; set; }

            /// <summary>
            /// string 否 退场时间
            /// </summary>
            public DateTime? exitTime { get; set; }

            /// <summary>
            /// string 否 进场确认附件资源地址
            /// </summary>
            public string entryAttachmentUrl { get; set; }

            /// <summary>
            /// string 否 退场确认附件资源地址
            /// </summary>
            public string exitAttachmentUrl { get; set; }

            /// <summary>
            /// int 否 参考数据字典：性别字典表
            /// </summary>
            public int gender { get; set; }

            /// <summary>
            /// string 否 出生日期,格式:yyyy-MM-dd
            /// </summary>
            public DateTime? birthday { get; set; }

            /// <summary>
            /// string 否 身份证号码前六位（籍贯）
            /// </summary>
            public string birth_place_code { get; set; }

            /// <summary>
            /// string 否 发卡时间。格式 yyyy-MM-dd
            /// </summary>
            public string issueCardDate { get; set; }

            /// <summary>
            /// string 否 办卡采集相片。不超过 50KB 的Base64 字符串
            /// </summary>
            public string issueCardPic { get; set; }

            /// <summary>
            /// string 否 考勤卡号
            /// </summary>
            public string cardNumber { get; set; }

            /// <summary>
            /// string 否 发放工资银行卡号。AES
            /// </summary>
            public string payRollBankCardNumber { get; set; }

            /// <summary>
            /// string 否 发放工资银行名称
            /// </summary>
            public string payRollBankName { get; set; }

            /// <summary>
            /// string 否 发放工资卡银行联号。
            /// </summary>
            public string bankLinkNumber { get; set; }

            /// <summary>
            /// string 否 发放工资卡银行。参考银行代码字典表
            /// </summary>
            public string payRollTopBankCode { get; set; }

            /// <summary>
            /// int 是 是否有劳动合同。参考是否字字典表
            /// 字典是int，实际接收是bool
            /// </summary>
            public bool hasContract { get; set; }

            /// <summary>
            /// int 否 是否购买工伤或意外伤害保险 。参考是否字典表
            /// 文档是int类型，实际上是bool类型
            /// </summary>
            public bool hasBuyInsurance { get; set; }

            /// <summary>
            /// 身份证地址
            /// </summary>
            public string address { get; set; }

            /// <summary>
            /// 联系电话
            /// </summary>
            public string cellPhone { get; set; }

            /// <summary>
            /// 签证机关
            /// </summary>
            public string grantOrg { get; set; }

            /// <summary>
            /// 身份证头像
            /// </summary>
            public string headImage { get; set; }

            /// <summary>
            /// 民族
            /// </summary>
            public string nation { get; set; }

            /// <summary>
            /// 人脸授权照片地址
            /// </summary>
            public string issueCardPicUrl { get; set; }

            /// <summary>
            /// 证件有效期开始日期。格式 yyyy-MM-dd
            /// </summary>
            public DateTime? startDate { get; set; }

            /// <summary>
            /// 证件有效期结束日期。格式 yyyy-MM-dd
            /// </summary>
            public DateTime? expiryDate { get; set; }
        }
    }
}
