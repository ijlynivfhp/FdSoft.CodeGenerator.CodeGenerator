using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base
{
    public class BaseRequest
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
        /// 项目编码
        /// </summary>
        public string projectCode { get; set; } = "";

        /// <summary>
        ///非必要参数。 工人所在企业统一社会信用代码， 如果无统一社会信用代码，则用组 织机构代码
        /// </summary>
        public string? corpCode { get; set; }

        /// <summary>
        /// 工人所在企业名称
        /// </summary>
        public string? corpName { get; set; }

        /// <summary>
        /// 对接登陆密码/对接密钥
        /// </summary>
        public string ApiPass { get; set; } = "";

        /// <summary>
        /// 验证请求
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        { 
            return !string.IsNullOrEmpty(ApiPass) && !string.IsNullOrEmpty(projectCode);
        }

    }
}
