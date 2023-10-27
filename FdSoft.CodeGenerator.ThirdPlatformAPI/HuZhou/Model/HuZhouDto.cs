using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzAttendanceResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceAccessResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceOnOffLineResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzGroupResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzProjectSubResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzProjectWorkerResponse;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model
{
    #region 基类
    public class HzRequestBase
    {
        /// <summary>
        /// 指定页号，以 0 为起始数字，表示 第 1 页
        /// </summary>
        public int pageIndex { get; set; } = 0;

        /// <summary>
        /// 每页记录数，最多不能超过 50
        /// </summary>
        public int pageSize { get; set; } = 50;

        /// <summary>
        /// 服务商ID
        /// 默认值：90b3ffc47b3642a1800b820eaf834696（正式）
        /// </summary>
        public string providerId { get; set; } = "90b3ffc47b3642a1800b820eaf834696";

        /// <summary>
        /// 项目编码
        /// </summary>
        public string projectCode { get; set; } = "";

        /// <summary>
        ///非必要参数。 工人所在企业统一社会信用代码， 如果无统一社会信用代码，则用组 织机构代码
        /// </summary>
        public string corpCode { get; set; }

        /// <summary>
        /// 工人所在企业名称
        /// </summary>
        public string corpName { get; set; }
        /// <summary>
        /// appKey
        /// </summary>
        public string appKey { get; set; }
        /// <summary>
        /// appSecret
        /// </summary>
        public string appSecret { get; set; }
    }

    public class HzResponsePageBase<T> where T : class, new()
    {

        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HzPageResponseData<T> Data { get; set; } = new HzPageResponseData<T>();

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; } = "";

    }

    public class HzPageResponseData<T> where T : class, new()
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount { get; set; }

        /// <summary>
        /// 指定页号，以 0 为起始数字，表示 第 1 页
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页记录数，最多不能超过 50
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int totalCount { get; set; }


        public List<T> rows { get; set; } = new List<T>();

    }

    public class HzResponseBase<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; } = "";
    }

    public class HzResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; } = "";
    }
    #endregion

    #region 请求实体
    /// <summary>
    /// 查询项目工人信息请求
    /// </summary>
    public class HzProjectWorkerRequest : HzRequestBase
    {
        /// <summary>
        /// 班组编号
        /// </summary>
        public string teamSysNo { get; set; }

        /// <summary>
        /// 证件号码，AES
        /// </summary>
        public string idCardNumber { get; set; }
    }

    /// <summary>
    /// 查询班组信息请求
    /// </summary>
    public class HzGroupRequest : HzRequestBase
    {
        /// <summary>
        /// 班组编号
        /// </summary>
        public string teamSysNo { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string teamName { get; set; }
    }

    /// <summary>
    /// 查询项目参建单位信息请求
    /// </summary>
    public class HzProjectSubRequest : HzRequestBase
    {

    }

    /// <summary>
    /// 查询工人考勤
    /// </summary>
    public class HzAttendanceRequest : HzRequestBase
    {
        /// <summary>
        ///   考勤日期， 格式 yyyy-MM-dd  必填
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 证件号码， AES后的
        /// </summary>
        public string idCardNumber { get; set; }
    }

    /// <summary>
    /// 获取设备详情信息
    /// </summary>
    public class HzDeviceRequest : HzRequestBase
    {
        /// <summary>
        /// 设备编码，不为空时多个编码以,隔开
        /// </summary>
        public string deviceNums { get; set; }
    }

    /// <summary>
    /// 获取设备秘钥信息
    /// </summary>
    public class HzDeviceAccessRequest : HzRequestBase
    {
        /// <summary>
        /// 设备编码，不为空时多个编码以,隔开
        /// </summary>
        public string deviceNums { get; set; }
    }

    /// <summary>
    /// 添加授权
    /// </summary>
    public class HzAddAuthorityRequest : HzRequestBase
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        public string deviceNum { get; set; }
        /// <summary>
        /// 人员列表信息
        /// </summary>
        public List<HzAddAuthorityRow> personList { get; set; }

        public class HzAddAuthorityRow
        {
            /// <summary>
            /// 人员ID
            /// </summary>
            public string personId { get; set; }
            /// <summary>
            /// 姓名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 身份证号
            /// </summary>
            public string idCardNumber { get; set; }
            /// <summary>
            /// 采集照片URL
            /// </summary>
            public string imgUrl { get; set; }
        }
    }

    /// <summary>
    /// 删除授权
    /// </summary>
    public class HzRemoveAuthorityRequest : HzRequestBase
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        public string deviceNum { get; set; }
        /// <summary>
        /// 人员列表信息
        /// </summary>
        public List<HzRemoveAuthorityRow> personList { get; set; }

        public class HzRemoveAuthorityRow
        {
            /// <summary>
            /// 人员ID
            /// </summary>
            public string personId { get; set; }
            /// <summary>
            /// 姓名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 身份证号
            /// </summary>
            public string idCardNumber { get; set; }
        }
    }

    /// <summary>
    /// 设备清空数据
    /// </summary>
    public class HzDeviceClearRequest : HzRequestBase
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        public string deviceNum { get; set; }
    }

    /// <summary>
    /// 获取设备在离线状态
    /// </summary>
    public class HzDeviceOnOffLineRequest : HzRequestBase
    {
        /// <summary>
        /// deviceNums string 否 设备编码，不为空时多个编码以,隔开
        /// </summary>
        public string deviceNums { get; set; }
    }
    #endregion

    #region 请求返回实体
    /// <summary>
    /// 查询项目工人信息响应
    /// </summary>
    public class HzProjectWorkerResponse : HzResponsePageBase<HzProjectWorkerRow>
    {

        /// <summary>
        /// 查询项目工人信息
        /// </summary>
        public class HzProjectWorkerRow
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
            /// int 是 班组编号
            /// </summary>
            public string teamSysNo { get; set; }

            /// <summary>
            /// string 是 班组名称
            /// </summary>
            public string teamName { get; set; }

            /// <summary>
            /// 人员ID（唯一）
            /// </summary>
            public string personId { get; set; }

            /// <summary>
            /// string 是 工人姓名
            /// </summary>
            public string workerName { get; set; }

            /// <summary>
            /// int 是 是否班组长。参考是否字典表
            /// 字典是int，实际接收是bool
            /// </summary>
            public int isTeamLeader { get; set; }

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
            public string workRole { get; set; }

            /// <summary>
            /// string 否 进场时间
            /// </summary>
            public string entryTime { get; set; }

            /// <summary>
            /// string 否 退场时间
            /// </summary>
            public string exitTime { get; set; }

            /// <summary>
            /// int 否 参考数据字典：性别字典表
            /// </summary>
            public string gender { get; set; }

            /// <summary>
            /// string 否 出生日期,格式:yyyy-MM-dd
            /// </summary>
            public string birthday { get; set; }

            /// <summary>
            /// string 否 身份证号码前六位（籍贯）
            /// </summary>
            public string birth_place_code { get; set; }

            /// <summary>
            /// 民族
            /// </summary>
            public string nation { get; set; }

            /// <summary>
            /// 考勤卡号
            /// </summary>
            public string cardNumber { get; set; }

            /// <summary>
            /// 人员身份证头像
            /// </summary>
            public string headImage { get; set; }

            /// <summary>
            /// 身份证地址
            /// </summary>
            public string address { get; set; }

            /// <summary>
            /// 发证机关
            /// </summary>
            public string grantOrg { get; set; }

            /// <summary>
            /// 有效期始
            /// </summary>
            public string startDate { get; set; }

            /// <summary>
            /// 有效期止
            /// </summary>
            public string expiryDate { get; set; }

            /// <summary>
            /// 手机号
            /// </summary>
            public string cellPhone { get; set; }

            /// <summary>
            /// 文化程度
            /// </summary>
            public string cultureLevelType { get; set; }

            /// <summary>
            /// 政治面貌
            /// </summary>
            public string politicsType { get; set; }

            /// <summary>
            /// 是否购买工伤或意外伤害保险，
            /// </summary>
            public int hasBuyInsurance { get; set; }

            /// <summary>
            /// 发放工资银行卡号
            /// </summary>
            public string payRollBankCardNumber { get; set; }

            /// <summary>
            /// 发放工资银行卡号
            /// </summary>
            public string payRollBankName { get; set; }

            /// <summary>
            /// 发放工资卡银行，详见字典
            /// </summary>
            public string payRollTopBankCode { get; set; }
        }
    }

    /// <summary>
    /// 查询班组信息响应
    /// </summary>
    public class HzGroupResponse : HzResponsePageBase<HzGroupRow>
    {
        /// <summary>
        /// 查询班组信息
        /// </summary>
        public class HzGroupRow
        {
            /// <summary>
            /// 班组编号
            /// </summary>
            public string teamSysNo { get; set; }
            /// <summary>
            /// 项目编码
            /// </summary>
            public string projectCode { get; set; }
            /// <summary>
            /// 班组所在企业统一社会信用代码， 如果无统一社会信用代码，则用组织机构代码
            /// </summary>
            public string corpCode { get; set; }

            /// <summary>
            /// 是否管理班组
            /// </summary>
            public string isManagerTeam { get; set; }

            /// <summary>
            /// 班组所在企业名称
            /// </summary>
            public string corpName { get; set; }
            /// <summary>
            /// 班组名称，同一个项目和参建单位下面不能重复
            /// </summary>
            public string teamName { get; set; }
            /// <summary>
            /// 责任人姓名，班组所在企业负责人
            /// </summary>
            public string responsiblePersonName { get; set; }
            /// <summary>
            /// 责任人联系电话
            /// </summary>
            public string responsiblePersonPhone { get; set; }
            /// <summary>
            /// 责任人身份证号码。AES
            /// </summary>
            public string responsiblePersonIDNumber { get; set; }
            /// <summary>
            /// 进场时间yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string entryTime { get; set; }
            /// <summary>
            /// 离场时间yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string exitTime { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string remark { get; set; }
        }
    }

    /// <summary>
    /// 查询项目参建单位信息响应
    /// </summary>
    public class HzProjectSubResponse : HzResponsePageBase<HzProjectSubRow>
    {
        /// <summary>
        /// 2.1.2查询项目参建单位信息
        /// </summary>
        public class HzProjectSubRow
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
            /// 项目经理名称
            /// </summary>
            public string pmName { get; set; }
            /// <summary>
            /// 项目经理证件号码。AES
            /// </summary>
            public string pmIDCardNumber { get; set; }
            /// <summary>
            /// 项目经理电话
            /// </summary>
            public string pmPhone { get; set; }
        }
    }

    /// <summary>
    /// 进退场记录响应数据
    /// </summary>
    public class HzAttendanceResponse : HzResponsePageBase<HzAttendanceResponseRow>
    {

        /// <summary>
        /// 进退场记录响应数据
        /// </summary>
        public class HzAttendanceResponseRow
        {
            /// <summary>
            /// 项目编码
            /// </summary>
            public string projectCode { get; set; }

            /// <summary>
            /// 人员所在企业统一社会信
            /// </summary>
            public string corpCode { get; set; }

            /// <summary>
            /// 人员所在企业名称
            /// </summary>
            public string corpName { get; set; }

            /// <summary>
            /// 班组编号
            /// </summary>
            public string teamSysNo { get; set; }

            /// <summary>
            /// 班组名称
            /// </summary>
            public string teamName { get; set; }

            /// <summary>
            /// 人员姓名
            /// </summary>
            public string workerName { get; set; }

            /// <summary>
            /// 证件号码。AES编码过的身份证号
            /// </summary>
            public string idCardNumber { get; set; }

            /// <summary>
            /// 工种或岗位名称
            /// </summary>
            public string workTypeName { get; set; }

            /// <summary>
            /// 工人类型名称
            /// </summary>
            public string workRoleName { get; set; }

            /// <summary>
            /// 刷卡时间， yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string date { get; set; }

            /// <summary>
            /// 刷卡进出方向。 进、出
            /// </summary>
            public string direction { get; set; }

            /// <summary>
            /// 考勤照片地址
            /// </summary>
            public string imageUrl { get; set; }

            /// <summary>
            /// 考勤设备编码
            /// </summary>
            public string sn { get; set; }
        }
    }

    /// <summary>
    /// 获取设备详情信息
    /// </summary>
    public class HzDeviceResponse : HzResponseBase<HzDeviceRow>
    {
        public class HzDeviceRow
        {
            /// <summary>
            /// 设备编码
            /// </summary>
            public string sn { get; set; }
            /// <summary>
            /// 设备名称
            /// </summary>
            public string deviceName { get; set; }
            /// <summary>
            /// 设备类型
            /// </summary>
            public string deviceType { get; set; }
            /// <summary>
            /// 进门，出门
            /// </summary>
            public string inOutType { get; set; }
            /// <summary>
            /// -success bool 是 存在即为true
            /// </summary>
            public bool success { get; set; }
            /// <summary>
            /// 描述信息
            /// </summary>
            public string msg { get; set; }
        }
    }

    /// <summary>
    /// 获取设备秘钥信息
    /// </summary>
    public class HzDeviceAccessResponse : HzResponseBase<HzDeviceAccessRow>
    {
        public class HzDeviceAccessRow
        {
            /// <summary>
            /// 设备编码
            /// </summary>
            public string sn { get; set; }
            /// <summary>
            /// accessId
            /// </summary>
            public string accessId { get; set; }
            /// <summary>
            /// accessKey
            /// </summary>
            public string accessKey { get; set; }
            /// <summary>
            /// accessSecret
            /// </summary>
            public string accessSecret { get; set; }
            /// <summary>
            /// 设备授权是否获取成功
            /// </summary>
            public bool success { get; set; }
            /// <summary>
            /// 描述信息
            /// </summary>
            public string msg { get; set; }
        }
    }

    /// <summary>
    /// 添加授权
    /// </summary>
    public class HzAddAuthorityResponse : HzResponseBase
    {

    }

    /// <summary>
    /// 删除授权
    /// </summary>
    public class HzRemoveAuthorityResponse : HzResponseBase
    {

    }

    /// <summary>
    /// 设备清空数据
    /// </summary>
    public class HzDeviceClearResponse : HzResponseBase
    {

    }

    /// <summary>
    /// 获取设备在离线状态
    /// </summary>
    public class HzDeviceOnOffLineResponse : HzResponseBase<HzDeviceOnOffLineRow>
    {
        public class HzDeviceOnOffLineRow
        {
            /// <summary>
            /// 设备编码
            /// </summary>
            public string sn { get; set; }
            /// <summary>
            /// 1 在线，0 离线
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 存在即为true
            /// </summary>
            public bool success { get; set; }
            /// <summary>
            /// 描述信息
            /// </summary>
            public string msg { get; set; }
        }
    }
    #endregion

    /// <summary>
    /// 海清人脸设备MQTT数据实体
    /// </summary>
    public class HaiQingBase<T>
    {
        public string messageId { get; set; }

        public string DataBegin { get { return "BeginFlag"; } }

        public int PersonNum { get; set; }

        public string @operator { get; set; }

        public T info { get; set; }

        public string DataEnd { get { return "EndFlag"; } }
    }
}
