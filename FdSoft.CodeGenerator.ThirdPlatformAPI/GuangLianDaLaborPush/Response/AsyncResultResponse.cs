using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Response
{
    /// <summary>
    /// 1.2.5 异步查询接口 响应体参数
    /// </summary>
    public class AsyncResultResponse : BaseResponse
    {
        /// <summary>
        /// string 是 异步请求码
        /// </summary>
        public string asyncRequestCode { get; set; }

        /// <summary>
        /// int 是 异步状态，参考 1.3.8 异步状态字典
        /// </summary>
        public int success { get; set; }

        /// <summary>
        /// string 是 项目id
        /// </summary>
        public string projectId { get; set; }

        /// <summary>
        /// String 是 处理结果描述
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// String 是 上传考勤时定义的编号
        /// </summary>
        public string curNumber { get; set; }
    }
}
