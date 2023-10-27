using FdSoft.CodeGenerator.Model.Enums;
using SequentialGuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Dto
{
    public partial class ComMQDto
    {
        #region 公用字段
        /// <summary>
        /// 消息唯一标识
        /// </summary>
        public string Id { get; set; } = SequentialGuidGenerator.Instance.NewGuid().ToString();
        /// <summary>
        /// 消息类型
        /// </summary>
        public ComMqTypeEnum Type { get; set; }
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 消息子类型
        /// </summary>
        public ComMqSubTypeEnum SubType { get; set; }
        /// <summary>
        /// 消息子类型名称
        /// </summary>
        public string SubTypeName { get; set; }
        /// <summary>
        /// 关键值int
        /// </summary>
        public int ComInt { get; set; }
        /// <summary>
        /// 关键值string
        /// </summary>
        public string ComStr { get; set; }
        /// <summary>
        /// 关键值Guid
        /// </summary>
        public Guid ComGuid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 消息内容
        /// </summary>
        public dynamic DycData { get; set; }
        /// <summary>
        /// 来源类型
        /// </summary>
        public ComMqSourceEnum Source { get; set; }
        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }
        /// <summary>
        /// 来源IP
        /// </summary>
        public string SourceIP { get; set; }
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool IsLog { get; set; } = true;
        /// <summary>
        /// 操作人
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 操作人名称
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region 备用字段
        public int SignInt { get; set; }
        public string SignStr { get; set; }
        public Guid SignGuid { get; set; }
        public DateTime SignDt { get; set; } = DateTime.Now;
        #endregion
    }

    public partial class ComMQDto<T> : ComMQDto
    {
        #region 公用字段
        public T Data { get; set; }
        #endregion
    }
}
