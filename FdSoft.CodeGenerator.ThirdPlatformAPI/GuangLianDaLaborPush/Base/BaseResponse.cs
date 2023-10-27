using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base
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
        public eCode code { get; set; } = eCode.其他;

        /// <summary>
        /// 处理结果描述
        /// </summary>
        public string message { get; set; }    
    }
}
