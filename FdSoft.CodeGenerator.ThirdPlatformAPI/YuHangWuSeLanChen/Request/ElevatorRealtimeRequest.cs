using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.ElevatorRealtimeRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request
{
    /// <summary>
    /// 2.1.3 上传升降机实时数据
    /// </summary>
    public class ElevatorRealtimeRequest : BaseRequest<ElevatorRealtime>
    {
        public class ElevatorRealtime
        {
            /// <summary>
            /// date 是 数据上传时间 格式: yyyy-MM-dd HH:mm:ss
            /// </summary>
            public DateTime uploadDate { get; set; }
            /// <summary>
            /// integer 是 实时起重量，单位：KG
            /// </summary>
            public int weight { get; set; }
            /// <summary>
            /// integer 是 重量百分比，单位：1 百分点
            /// </summary>
            public int weightPercent { get; set; }
            /// <summary>
            /// integer 是 实时人数
            /// </summary>
            public int personNum { get; set; }
            /// <summary>
            /// integer 是 实时高度，单位：0.1 米
            /// </summary>
            public int height { get; set; }
            /// <summary>
            /// integer 是 高度百分比，单位：1 百分点
            /// </summary>
            public int heightPercent { get; set; }
            /// <summary>
            /// integer 是 实时速度，单位：0.1 米/秒
            /// </summary>
            public int speed { get; set; }
            /// <summary>
            /// integer 是 速度方向，参考升降机实时数据速度方向字典表
            /// </summary>
            public ElevatorRealtimeSpeedDirection speedStatus { get; set; }
            /// <summary>
            /// integer 是 实时 X 向倾斜度，单位：0.01 度
            /// </summary>
            public int tilt1 { get; set; }
            /// <summary>
            /// integer 是 X 向倾斜百分比 ，单位：1 百分点
            /// </summary>
            public int tiltPercent1 { get; set; }
            /// <summary>
            /// integer 是 实时 Y 向倾斜度 ，单位：0.01 度
            /// </summary>
            public int tilt2 { get; set; }
            /// <summary>
            /// integer 是 Y 向倾斜百分比 ，单位：1 百分点
            /// </summary>
            public int tiltPercent2 { get; set; }
            /// <summary>
            /// string 是 驾驶员身份认证结果，0 为未认证，非零为驾驶员工号
            /// </summary>
            public string authen { get; set; }
            /// <summary>
            /// integer 是 前门状态，参考开关字典表
            /// </summary>
            public ElevatorDoorStatusEnum foreDoorStatus { get; set; }
            /// <summary>
            /// integer 是 后门状态，参考开关字典表
            /// </summary>
            public ElevatorDoorStatusEnum behindDoorStatus { get; set; }
            /// <summary>
            /// integer 是 门锁异常指示,参考正异常字典表
            /// </summary>
            public ElevatorDoorLockStatusEnum lockStatus { get; set; }
        }
    }
}