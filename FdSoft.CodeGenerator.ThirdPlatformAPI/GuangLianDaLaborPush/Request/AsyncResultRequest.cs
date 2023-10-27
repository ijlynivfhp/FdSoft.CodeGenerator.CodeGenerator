using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request
{
    /// <summary>
    /// 1.2.5 异步查询接口
    /// </summary>
    public class AsyncResultRequest : BaseRequest
    {
        [JsonIgnore]
        public AsyncResult Body { get; set; } = new AsyncResult();

        public class AsyncResult
        {
            /// <summary>
            /// string 是 异步请求码
            /// </summary>
            public string asyncRequestCode { get; set; }
        }
    }
}