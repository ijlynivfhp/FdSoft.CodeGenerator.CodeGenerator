using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Response
{
    public class AttendanceResponse : BaseResponse
    {
        public Attendance Body { get; set; } = new Attendance();

        public class Attendance
        {
            /// <summary>
            /// 异步任务ID
            /// </summary>
            public string asyncRequestCode { get; set; }

            /// <summary>
            /// 异步状态
            /// </summary>
            public int asyncStatus { get; set; }


            public string result { get; set; }
    }
    }
}
