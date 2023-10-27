using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums;
using Newtonsoft.Json;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request
{
    /// <summary>
    /// 1.2.1新增和修改企业信息
    /// </summary>
    public class ProjectCorporationRequest : BaseRequest
    {
        [JsonIgnore]
        public ProjectCorporation Body { get; set; } = new ProjectCorporation();

        public class ProjectCorporation
        {
            /// <summary>
             /// string 是 企业名称
             /// </summary>
            public string name { get; set; }
            /// <summary>
            /// string 是 统一社会信用代码,项目下唯一
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// string 是 参建类型,参考 1.3.1 参建类型字典
            /// </summary>
            public string type { get; set; }

            //businessScope string 否 经营范围
            //registerDate string 否 注册日期，格式：yyyy-MM-dd
            //establishDate string 否 成立日期，格式：yyyy-MM-dd
            //legalMan string 否 法定代表人
            //legalManIdCardNumber string 否 法定代表人身份证号码
            //legalManPhone string 否 法定代表人联系电话
            //regCapital decimal 否 注册资本（单位：万元）
            //factRegCapital decimal 否 实收资本（单位：万元）
            //address string 否 营业地址
            //zipCode string 否 邮政编码
            //officePhone string 否 企业联系电话
            //linkMan string 否 联系人姓名
            //linkPhone string 否 联系人办公电话
            //email string 否 企业邮箱
            //enterDate string 否 进场日期
            //exitDate string 否 退场日期
            //registerArea string 否 企业注册地址
            //licenseNum string 否 企业营业执照号
            //capitalCurrencyType string 否 注册资本币种（类型：万元，吨，CNY）
            //safetyLicenseNum string 否 安全施工许可证号
            //safetyLicenseDate string 否 安全施工许可证有效日期
            //safetyLicenseOrg string 否 安全施工许可证发证机关
            //legalManDuty string 否 法定代表人职务
            //legalManTitle string 否 法定代表人职称
            //legalManIdCardType string 否 法定代表人证件类型
            //businessAddress string 否 营业地址
            //faxNumber string 否 传真号码
            //website string 否 企业网址
            //responsiblePersonName string 否 企业负责人姓名
            //responsiblePersonPhone string 否 企业负责人电话
            //responsiblePersonIdCard
            //Type
            //string 否 企业负责人证件类型
            //responsiblePersonIdNum
            //ber
            //string 否 企业负责人证件号码
            //bankName string 否 银行支行名称
            //bankCode string 否 银行代码
            //bankNumber string 否 银行卡号
            //bankLinkNumber string 否 银行联号
            //bond double 否 企业保证金
            //laborCapitalManager string 否 劳资专管员姓名
            //laborCapitalManagerPho
            //ne
            //string 否 劳资专管员联系电话
            //laborCapitalManagerIdC
            //ardType
            //string 否 劳资专管员证件类型
            //laborCapitalManagerIdC
            //ardNumber
            //string 否 劳资专管员证件号码

            /// <summary>
            /// Long 否 企业编码，企业上传成功返回的编码，新增企业不填，更新企业必填。 
            /// </summary>
            public long? companyCode { get; set; }
        }
    }
}
