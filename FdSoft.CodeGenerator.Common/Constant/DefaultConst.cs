using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Constant
{
    public class DefaultConst
    {
        /// <summary>
        /// 班组工种编号
        /// </summary>
        public const string GroupTypeCode = "1000";
        /// <summary>
        /// 班组工种名称
        /// </summary>
        public const string GroupTypeName = "其它";
        /// <summary>
        /// 工人工种编号
        /// </summary>
        public const string WorkerTypeCode = "1000";
        /// <summary>
        /// 工人工种名称
        /// </summary>
        public const string WorkerTypeName = "其它";
        /// <summary>
        /// 管理人员工种编号
        /// </summary>
        public const string ManagerWorkerTypeCode = "1099";
        /// <summary>
        /// 管理人员工种名称
        /// </summary>
        public const string ManagerWorkerTypeName = "其它";


        public const string CorpCode = "330000";

        /// <summary>
        /// 推送劳务数据到第三方平台失败尝试最大次数
        /// </summary>
        public const int MaxPushLaborFailedCount = 3;

        /// <summary>
        /// 年龄不符最小值
        /// </summary>
        public const int MinAge = 18;

        /// <summary>
        /// 女 年龄不符最大值
        /// </summary>
        public const int FemaleMaxAge = 60;

        /// <summary>
        /// 男 年龄不符最大值
        /// </summary>
        public const int MaleMaxAge = 65;

        /// <summary>
        /// 设备最后在线时间小于5分钟，属于在线
        /// </summary>
        public const int DeviceLostMinute = 5;
    }
}
