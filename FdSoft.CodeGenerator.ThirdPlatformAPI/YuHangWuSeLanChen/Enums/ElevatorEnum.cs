using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums
{
    /// <summary>
    /// 3.3 升降机实时数据速度方向字典表
    /// </summary>
    public enum ElevatorRealtimeSpeedDirection
    {
        停止 = 0,
        上 = 1,
        下 = 2,
    }

    /// <summary>
    /// 3.4 升降机工作循环数据起升方向字典表
    /// </summary>
    public enum ElevatorGroupRunDirection
    {
        停止 = 0,
        下 = 1,
        上 = 2,
    }

    /// <summary>
    /// 3.5 开关字典表
    /// </summary>
    public enum ElevatorDoorStatusEnum
    {
        关闭 = 0,
        开启 = 1,
    }

    /// <summary>
    /// 3.6 正异常字典表
    /// </summary>
    public enum ElevatorDoorLockStatusEnum
    {
        正常 = 0,
        异常 = 1,
    }

    /// <summary>
    /// 3.7 升降机报警事件字典表
    /// </summary>
    public enum ElevatorAlarmEnum
    {
        升降机正常 = 1000,
        升降机人数预警 = 1001,
        升降机重量预警 = 1002,
        升降机倾斜预警 = 1003,
    }
}
