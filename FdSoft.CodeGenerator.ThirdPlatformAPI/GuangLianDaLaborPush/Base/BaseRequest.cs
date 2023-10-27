using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base
{
    public class BaseRequest
    {
        /// <summary>
        /// 用户唯一凭证
        /// </summary>
        public string appId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 用户唯一凭证秘钥
        /// </summary>
        public string secret { get; set; }

        /// <summary>
        /// 标段唯一编码 由对接人提供
        /// </summary>
        public string projectCode { get; set; }

        /// <summary>
        /// 加密后的字符串。把数据先转换成 json，然后进行AES 加密
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// 随机数，10 分钟内不允许重复
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// 时间戳，格式：yyyyMMddHHmmss。仅接收时间差在 10 分钟内的数据
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 签名，根据签名算法得来
        /// </summary>
        public string sign { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 对接账号 appId 数据库对应字段
        /// </summary>
        public string ApiUser
        {
            get
            {
                return appId;
            }
            set
            {
                appId = value;
            }
        }

        [JsonIgnore]
        /// <summary>
        /// 对接密钥 secret 数据库对应字段
        /// </summary>
        public string ApiPass
        {
            get
            {
                return secret;
            }
            set
            {
                secret = value;
            }
        }

        /// <summary>
        /// 验证请求
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            return !string.IsNullOrEmpty(appId) 
                && !string.IsNullOrEmpty(secret)
                && !string.IsNullOrEmpty(projectCode);
        }
    }
}
