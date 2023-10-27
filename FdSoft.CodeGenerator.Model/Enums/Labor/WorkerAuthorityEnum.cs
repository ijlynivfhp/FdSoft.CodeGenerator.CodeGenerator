using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    public enum AuthorityDeviceTypeEnum
    {
        [Description("刷卡授权")]
        刷卡授权 = 1,
        [Description("人脸授权")]
        人脸授权 = 2,
        [Description("刷卡+人脸")]
        刷卡人脸 = 3,
    }

    public enum AuthStatusEnum
    {
        [Description("未授权")]
        未授权 = 0,
        [Description("已授权")]
        已授权 = 1
    }

    /// <summary>
    /// 1授权中2授权成功3授权失败
    /// </summary>
    public enum AuthLogStatusEnum
    {
        [Description("授权中")]
        授权中 = 1,
        [Description("授权或取消授权成功")]
        授权或取消授权成功 = 2,
        [Description("授权失败")]
        授权失败 = 3,
        [Description("已抛弃")]
        已抛弃 = 4,
    }

    /// <summary>
    /// 授权结果类型
    /// </summary>
    public enum AuthResultTypeEnum
    {
        [Description("默认")]
        默认 = 0,
        [Description("授权成功")]
        授权成功 = 5,
        [Description("取消授权成功")]
        取消授权成功 = 10,
        [Description("授权照片异常")]
        授权照片异常 = 15,
        [Description("设备不在线")]
        设备不在线 = 20,
        [Description("未检测到面部")]
        未检测到面部 = 25,
        [Description("授权失败")]
        授权失败 = 30,
        [Description("已抛弃")]
        已抛弃 = 35,
        [Description("卡号不存在")]
        卡号不存在 = 40,
    }

    public enum AuthImgType
    {
        [Description("图片")]
        Img = 5,
        [Description("外网路径")]
        Url = 10
    }
}
