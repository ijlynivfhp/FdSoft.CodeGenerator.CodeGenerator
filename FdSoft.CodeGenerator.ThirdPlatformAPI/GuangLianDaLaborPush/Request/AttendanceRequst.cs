using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request.TeamGroupRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request
{
    /// <summary>
    /// 3.6 添加劳务人员出勤记录
    /// </summary>
    public class AttendanceRequest : BaseRequest
    {
        [JsonIgnore]
        public List<Attendance> Body { get; set; } = new List<Attendance>();

        public class Attendance
        {
            /// <summary>
            /// string 是 身份证号
            /// </summary>
            public string identification { get; set; }

            /// <summary>
            /// string 是 刷卡时间，格式：yyyy-MM-dd HH:mm:ss
            /// </summary>
            public string swipeTime { get; set; }

            /// <summary>
            /// int 是 考勤方向，1：入场，0：出场
            /// </summary>
            public int swipeType { get; set; }

            /// <summary>
            /// string 否 刷卡照片，url
            /// </summary>
            public string image { get; set;}

            /// <summary>
            /// int 是 通行方式，参考 1.3.7 通行方式字典
            /// </summary>
            public int attendType { get; set; }

            /// <summary>
            /// string 是 考勤编号。当前数据在数组中的唯一标识，响应结果会返回
            /// </summary>
            public string curNumber { get; set; }

            /// <summary>
            /// string 否 设备编码
            /// </summary>
            public string deviceCode { get; set; }

            //workPointName string 否 刷卡地点
            //temperature string 否 体温
            //epidemicVO object 否 疫情信息
        }
    }
}
