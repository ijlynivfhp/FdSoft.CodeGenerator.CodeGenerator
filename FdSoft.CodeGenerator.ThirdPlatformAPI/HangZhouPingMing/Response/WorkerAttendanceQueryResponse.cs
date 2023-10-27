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
    public class WorkerAttendanceQueryResponse : BaseResponse<WorkerAttendanceQueryResponseRow>
    {

    }

    /// <summary>
    /// 进退场记录响应数据
    /// </summary>
    public class WorkerAttendanceQueryResponseRow
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        public string projectCode { get; set; }

        /// <summary>
        /// 班组编号
        /// </summary>
        public int teamSysNo { get; set; }

        /// <summary>
        /// 证件类型。参考人员证件类型字典表  01身份证
        /// </summary>
        public string idCardType { get; set; }

        /// <summary>
        /// 证件号码。AES编码过的身份证号
        /// </summary>
        public string idCardNumber { get; set; }

        /// <summary>
        /// 刷卡时间， yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 刷卡进出方向。 01入场  02 出场
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// 刷卡近照。 Base64 字符串， 不超 过 50KB
        /// </summary>
        public string image { get; set; }

        /// <summary>
        /// 通道的名称
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// 通行方式。 
        /// </summary>
        public string attendType { get; set; }

        /// <summary>
        /// WGS84 经度
        /// </summary>
        public long lng { get; set; }

        /// <summary>
        /// WGS84 纬度
        /// </summary>
        public int lat { get; set; }
    }

}
