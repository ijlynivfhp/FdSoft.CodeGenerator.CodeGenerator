using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.ElevatorGroupRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.4 上传升降机工作循环数据
    /// </summary>
    public class ElevatorGroupRequest : BaseRequest<ElevatorGroup>
    {
        public class ElevatorGroup
        {
            /// <summary>
            /// date 是 数据上传时间 格式: yyyy-MM-dd HH:mm:ss
            /// </summary>
            public DateTime uploadDate { get; set; }
            /// <summary>
            /// date 是 工作循环开始时间 格式: yyyy-MM-dd HH:mm:ss
            /// </summary>
            public DateTime beginDate { get; set; }
            /// <summary>
            /// date 是 工作循环结束时间 格式: yyyy-MM-dd HH:mm:ss
            /// </summary>
            public DateTime endDate { get; set; }
            /// <summary>
            /// string 是 驾驶员姓名，全 0 代表未认证
            /// </summary>
            public string driverName { get; set; }
            /// <summary>
            /// string 是 驾驶员身份证号，全 0 代表未认证
            /// </summary>
            public string driverCardNo { get; set; }
            /// <summary>
            /// integer 是 本次载重，单位：KG
            /// </summary>
            public int weight { get; set; }
            /// <summary>
            /// integer 是 本次载重百分比，单位：1 百分点
            /// </summary>
            public int weightPercent { get; set; }
            /// <summary>
            /// integer 是 本次起升起点高度，单位：0.1 米
            /// </summary>
            public int startHeight { get; set; }
            /// <summary>
            /// integer 是 本次起升终点高度，单位：0.1 米
            /// </summary>
            public int endHeight { get; set; }
            /// <summary>
            /// integer 是 本次起升的行程高度，单位：0.1 米
            /// </summary>
            public int tripHeight { get; set; }
            /// <summary>
            /// integer 是 本次起升方向，参考升降机工作循环数据起升方向字典表
            /// </summary>
            public ElevatorGroupRunDirection liftingDirection { get; set; }
            /// <summary>
            /// integer 是 本次起升平均速度，单位：0.1 米/秒
            /// </summary>
            public int avgSpeed { get; set; }
            /// <summary>
            /// integer 是 本次起升最大 X 向倾斜度，单位：0.01 度
            /// </summary>
            public int maxXTilt { get; set; }
            /// <summary>
            /// integer 是 本次起升最大 Y 向倾斜度，单位：0.01 度
            /// </summary>
            public int maxYTilt { get; set; }
            /// <summary>
            /// integer 是 本次装载人数
            /// </summary>
            public int loadPersons { get; set; }
            /// <summary>
            /// string 是 报警类型，参考升降机报警事件字典表
            /// </summary>
            public ElevatorAlarmEnum warningState { get; set; }
        }
    }
}