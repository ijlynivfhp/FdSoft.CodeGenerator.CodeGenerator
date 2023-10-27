using FdSoft.CodeGenerator.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerAlarmRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base
{
    public class BaseRequest<T>
    {
        [JsonIgnore]
        /// <summary>
        /// 设备编号
        /// </summary>
        public string deviceSerialNo { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 用户唯一凭证
        /// </summary>
        public string softwareSecretKey { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 用户唯一凭证秘钥
        /// </summary>
        public string hardwareSecretKey { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 标段唯一编码 由对接人提供
        /// </summary>
        public string projectSecretKey { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 请求url中action部分
        /// </summary>
        public string action { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 子级实体
        /// </summary>
        public T subBody { get; set; }

        /// <summary>
        /// 加密后的字符串。把数据先转换成 json，然后进行AES 加密
        /// </summary>
        public string data
        {
            get
            {
                return JsonConvert.SerializeObject(subBody);
            }
        }

        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; } = DateTime.Now.DateTimeToLong();

        /// <summary>
        /// 签名，根据签名算法得来
        /// </summary>
        public string sign { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 对接项目编码 ProjectCode 数据库对应字段
        /// </summary>
        public string ProjectCode
        {
            get
            {
                return projectSecretKey;
            }
            set
            {
                projectSecretKey = value;
            }
        }

        /// <summary>
        /// 验证请求
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            return !string.IsNullOrEmpty(softwareSecretKey) 
                && !string.IsNullOrEmpty(hardwareSecretKey)
                && !string.IsNullOrEmpty(projectSecretKey);
        }
    }
}
