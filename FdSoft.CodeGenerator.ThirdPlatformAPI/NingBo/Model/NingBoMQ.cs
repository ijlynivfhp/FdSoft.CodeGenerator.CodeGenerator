using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.NingBo.Model
{
    public class NingBoMQ
    {
        /// <summary>
        /// 项目主键
        /// </summary>
        public Guid ProId { get; set; }

        /// <summary>
        /// 数据主体
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public NingBoSourceEnum DataSource { get; set; }
    }

    /// <summary>
    /// 人脸设备MQ数据源
    /// </summary>
    public enum NingBoSourceEnum
    {
        Web删除工人 = 0,
        Web退场工人 = 1,
        Web授权操作 = 2,
        Web新增设备 = 3,
        Web重推门区下所有工人 = 4,
        Server轮询重发 = 5,
        Web设备清空数据 = 6,
        Server宁波甬建码 = 7,
        Web工人下发到设备 = 8,
        DataCenter = 25,
    }

    /// <summary>
    /// 宁波操作人
    /// </summary>
    public enum NingBoOperator
    {
        /// <summary>
        /// 批量删除人员
        /// </summary>
        [Description("DeletePersons")]
        DeletePersons,
        /// <summary>
        /// 批量添加修改人员
        /// </summary>
        [Description("EditPersonsNew")]
        EditPersonsNew,
    }
}
