using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using Newtonsoft.Json;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request
{
    /// <summary>
    /// 3.5 添加劳务人员基本信息
    /// </summary>
    public class WorkerRequest : BaseRequest
    {
        [JsonIgnore]
        public Worker Body { get; set; } = new Worker();

        public class Worker
        {
            /// <summary>
            /// string 是 企业统一社会信用代码
            /// </summary>
            public string companyCode { get; set; }

            /// <summary>
            /// string 是 班组上传成功返回的班组编码
            /// </summary>
            public string groupCode { get; set; }

            /// <summary>
            /// string 是 人员姓名
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// string 是 身份证号
            /// </summary>
            public string identification { get; set; }

            /// <summary>
            /// string 是 身份证有效期的开始日期，格式 yyyy-MM-dd
            /// </summary>
            public string startExpiration { get; set; }

            /// <summary>
            /// string 是 身份证有效期的结束日期，格式 yyyy-MM-dd，长期有效取值：2099-12-31
            /// </summary>
            public string endExpiration { get; set; }

            /// <summary>
            /// string 是 签发机关
            /// </summary>
            public string issuingUnit { get; set; }

            /// <summary>
            /// string 是 住址
            /// </summary>
            public string address { get; set; }

            /// <summary>
            /// string 是 民族，填写编码，参考 1.3.2 民族字典
            /// </summary>
            public string ethnic { get; set; }

            /// <summary>
            /// string 否 联系电话
            /// </summary>
            public string phone { get; set; }

            /// <summary>
            /// string 是 身份证图片，url
            /// </summary>
            public string photo { get; set; }

            /// <summary>
            /// string 否 近照，url
            /// </summary>
            //public string recentPhoto { get; set; }

            /// <summary>
            /// string 否 身份证复印件正面照，url
            /// </summary>
            //public string identificationCopyFront { get; set; }

            /// <summary>
            /// string 否 身份证复印件反面照，url
            /// </summary>
            //public string identificationCopyBack { get; set; }

            /// <summary>
            /// string 否 政治面貌，填写编码，参考 1.3.3 政治面貌字典
            /// </summary>
            //public string politicalStatus { get; set; }

            /// <summary>
            /// string 否 文化程度，填写编码，参考 1.3.4 文化程度字典
            /// </summary>
            //public string degreeName { get; set; }

            /// <summary>
            /// string 否 紧急联系人
            /// </summary>
            //public string urgentContact { get; set; }

            /// <summary>
            /// string 否 紧急联系人电话
            /// </summary>
            //public string urgentTel { get; set; }

            /// <summary>
            /// string 是 人员角色，0：工人，1：管理人员
            /// </summary>
            public string postType { get; set; }

            /// <summary>
            /// int 是 是否班组长，1 是，0 否
            /// </summary>
            public string isLeader { get; set; }

            /// <summary>
            /// string 是 工种/岗位编码，填写编码 若是工人，参考 1.3.5 工种字典，若是管理人员，参考 1.ic g insrt3.6 lbu岗p位字典
            /// </summary>
            public string workTypeCode { get; set; }

            /// <summary>
            /// string 是 进场（也称入职）日期，格式：yyyy-MM-dd
            /// </summary>
            public string enterDate { get; set; }

            /// <summary>
            /// string 否 退场（也称离职）日期，进场时，这个值为空；退场时，必填，格式：yyyy-MM-dd
            /// </summary>
            public string exitDate { get; set; }

            /// <summary>
            /// Long 否 出生日期
            /// </summary>
            //public string birthDate { get; set; }

            /// <summary>
            /// string 否 血型
            /// </summary>
            //public string bloodType { get; set; }

            /// <summary>
            /// string 否 银行卡号
            /// </summary>
            //public string bankCode { get; set; }

            /// <summary>
            /// string 否 银行名称
            /// </summary>
            //public string bankName { get; set; } 
        }
    }
}
