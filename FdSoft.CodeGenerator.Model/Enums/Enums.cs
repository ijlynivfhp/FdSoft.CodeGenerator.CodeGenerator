using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    /// <summary>
    /// 状态枚举值，
    /// </summary>
    public enum StatusCodeEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Nomal = 0,

        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")]
        Deleted = 1,
    }


    /// <summary>
    /// 进场/出场类型
    /// </summary>
    public enum DeliveryTypeEnum
    {
        /// <summary>
        /// 进场/收料
        /// </summary>
        [Description("收料")]
        InnerDelivery = 0,

        /// <summary>
        /// 出场/发料
        /// </summary>
        [Description("发料")]
        OuterDelivery = 1,
    }

    /// <summary>
    /// Material_Order重量偏差结果
    /// </summary>
    public enum OffsetResult
    {
        未设置偏差 = 0, 超正差 = 1, 正常 = 2, 超负差 = 3
    }

    /// <summary>
    /// Material_Order订单来源
    /// </summary>
    public enum OrderSource
    {
        称重 = 1, 补录 = 2, 移动验收 = 3
    }


    /// <summary>
    /// 附件类型枚举
    /// </summary>
    public enum BizType
    {
        /// <summary>
        /// 现场进场照片
        /// </summary>
        [Description("现场进场照片")]
        InnerImg = 1,

        /// <summary>
        /// 现场出场照片
        /// </summary>
        [Description("现场出场照片")]
        OuterImg = 2,

        /// <summary>
        /// 票据照片
        /// </summary>
        [Description("票据照片")]
        OrderImg = 3
    }

    public enum EarlyWarnTypeEnum
    {
        超负差 = 1,
        车辆进出异常 = 2
    }

    /// <summary>
    /// 风险预警
    /// </summary>
    public enum EarlyWarning
    {
        待处理 = 0,
        已处理 = 1
    }

    /// <summary>
    /// 打印状态
    /// </summary>
    public enum PrintStatus
    {
        已打印 = 1,
        未打印 = 2
    }

    /// <summary>
    /// 磅单类型
    /// </summary>
    public enum OrderType
    {
        收货中 = 0,
        已收货 = 1,
        已取消 = 2
    }

    public enum ComDateTypeEnum
    {
        日 = 1,
        月 = 2,
        年 = 3
    }

    /// <summary>
    /// 第三方平台公用
    /// </summary>
    public enum ThirdPlatformEnum
    {
        /// <summary>
        /// 品铭单双发设备配置
        /// </summary>
        SingleDoublePinMinConfig = 10,
    }

    /// <summary>
    /// 数据范围类型(1日，2月，3年) 
    /// </summary>
    public enum RangeTypeEnum
    {
        日 = 1,
        月 = 2,
        年 = 3
    }
}
