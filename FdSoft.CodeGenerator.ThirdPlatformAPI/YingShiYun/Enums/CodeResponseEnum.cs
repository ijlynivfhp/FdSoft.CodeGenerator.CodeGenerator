using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun.Enums
{
    /// <summary>
    /// 返回编码
    /// </summary>
    public enum CodeResponseEnum
    {
        成功 = 200,
        参数错误 = 10001,
        accessToken异常或过期 = 10002,
        用户不存在 = 10004,
        appKey异常 = 10005,
        appKey不存在 = 10017,
        设备数量超出个人版限制请充值企业版 = 10026,
        设备不存在 = 20002,
        设备不在线 = 20007,
        deviceSerial不合法 = 20014,
        该用户不拥有该设备 = 20018,
        该用户下通道不存在 = 20032,
        不支持该命令 = 60020,
        地址未绑定 = 60060,
        数据异常 = 49999,
    }
}
