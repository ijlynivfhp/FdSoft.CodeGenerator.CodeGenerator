using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun.Enums;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun.Base
{
    public class BaseResponse
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// 返回 code，详见下面 code 定义
        /// </summary>
        public CodeResponseEnum code { get; set; }

        /// <summary>
        /// 处理结果描述
        /// </summary>
        public string message { get; set; }    
    }
}
