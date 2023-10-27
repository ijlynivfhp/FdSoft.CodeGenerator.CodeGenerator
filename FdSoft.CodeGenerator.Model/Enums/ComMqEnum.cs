using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    /// <summary>
    /// ComMq公共类型枚举类
    /// </summary>
    public enum ComMqTypeEnum
    {
        [Description("默认")]
        Default = 0,
        [Description("单双发设备新增")]
        SingleDoubleAdd = 10,
        [Description("单双发设备删除")]
        SingleDoubleDel = 11,
        [Description("双发设备新增或删除通知")]
        SingleDoubleAddOrDel = 12,
        [Description("单双发设备考勤上传")]
        SingleDoubleAttendance = 13,
        [Description("单双发设备上线下线队列")]
        SingleDoubleOnOffLine = 100,
        [Description("单双发设备配置获取")]
        SingleDoubleGetConfig = 15,
        [Description("单双发设备配置设置")]
        SingleDoubleSetConfig = 20,
        [Description("单双发设备重启")]
        SingleDoubleReBoot = 25,
        [Description("单双发设备重置")]
        SingleDoubleReSet = 30,

        #region 设备指令相关
        [Description("设备配置")]
        ConfigToDevice = 50,
        #endregion

        #region 人员设备授权销权相关
        [Description("人员设备授权销权")]
        Authority = 70,
        #endregion

        #region 考勤数据
        [Description("考勤数据")]
        Attendance = 80,
        #endregion

        #region 设备状态（在线，离线）
        [Description("设备状态")]
        DeviceOnOffLine = 85,
        #endregion

        #region 交互方式
        [Description("宇泛单双发")]
        YfSingleDouble = 110,
        [Description("宇泛沃海思")]
        YfWoHaiSi = 115,
        [Description("宇泛沃土安卓")]
        YfWoTuAndroid = 120,
        [Description("微根主板")]
        WgShuaKa = 125,
        [Description("海清宁波")]
        HqNingBo = 130,
        [Description("湖洲直发")]
        HuZhouZf = 135,
        #endregion

        #region 项目工人数据
        [Description("项目工人数据")]
        ProjectWorker = 150,
        #endregion

        #region 授权后更新授权日志，授权，项目工人
        [Description("授权后更新状态")]
        SetStatusAfterAuth = 160,
        #endregion

        #region 查询处理设备中人员
        [Description("查询设备中人员")]
        DevicePersonsQuery = 165,
        [Description("处理设备中人员")]
        DevicePersonsHandle = 170,
        #endregion

        #region IoT设备
        [Description("AI")]
        IoTAI = 200,
        [Description("监控视频")]
        IoTVedio = 204,
        [Description("塔吊")]
        IoTTower = 205,
        [Description("扬尘")]
        IoTDust = 206,
        [Description("升降梯")]
        IoTElevator = 208,
        [Description("安全帽")]
        IoTHelmet = 209,
        [Description("水")]
        IoTWater = 210,
        [Description("电")]
        IoTElec = 210,
        #endregion

    }

    /// <summary>
    /// ComMq公共子类型枚举类
    /// </summary>
    public enum ComMqSubTypeEnum
    {
        #region 设备控制（不同指令）
        [Description("设备配置获取")]
        GetDeviceConfig = 50,
        [Description("设备配置设置")]
        SetDeviceConfig = 55,
        [Description("设备重启")]
        ReBootDevice = 60,
        [Description("设备重置")]
        ReSetDevice = 65,
        #endregion

        #region 授权相关（不同维度）
        /// <summary>
        /// 项目工人管理
        /// </summary>
        [Description("项目工人管理")]
        AuthByWorker = 100,
        /// <summary>
        /// 设备管理重推
        /// </summary>
        [Description("设备管理重推")]
        RePushToDevice = 105,
        /// <summary>
        /// 门区管理一键授权
        /// </summary>
        [Description("门区管理一键授权")]
        AuthByGate = 110,
        /// <summary>
        /// 项目工人管理批量授权门区
        /// </summary>
        [Description("项目工人管理批量授权门区")]
        AuthByBatchWorkersGates = 115,
        /// <summary>
        /// 批量删除项目工人
        /// </summary>
        [Description("批量删除项目工人")]
        UnAuthByBatchDelWorkers = 120,
        /// <summary>
        /// 批量退场项目工人
        /// </summary>
        [Description("批量退场项目工人")]
        UnAuthByBatchOutWorkers = 125,
        /// <summary>
        /// 批量进退场项目工人
        /// </summary>
        [Description("批量进退场项目工人")]
        UnAuthByBatchJoinOutWorkers = 130,
        /// <summary>
        /// 项目工人批量卡号解绑
        /// </summary>
        [Description("项目工人批量卡号解绑")]
        UnAuthByBatchCardNos = 135,
        /// <summary>
        /// 项目工人进场
        /// </summary>
        [Description("项目工人进场")]
        AuthByJoinWorker = 140,
        /// <summary>
        /// 项目工人退场
        /// </summary>
        [Description("项目工人退场")]
        AuthByOutWorker = 145,
        /// <summary>
        /// Excel导入人员 批量退场，风险预警 批量退场
        /// </summary>
        [Description("批量退场")]
        UnAuthByBatchOut = 145,
        /// <summary>
        /// 接收设备总数据
        /// </summary>
        [Description("接收设备总数据")]
        AuthByHandleMqData = 150,
        /// <summary>
        /// 湖州平台添加人员
        /// </summary>
        [Description("湖州平台添加人员")]
        AuthByHuZhouTryAddWorker = 155,
        /// <summary>
        /// 杭州平台添加人员
        /// </summary>
        [Description("杭州平台添加人员")]
        AuthByHangZhouTryAddWorker = 160,
        /// <summary>
        /// 杭州平台删除人员
        /// </summary>
        [Description("杭州平台删除人员")]
        AuthByHangZhouTryDelWorker = 165,
        /// <summary>
        /// 设备清空
        /// </summary>
        [Description("设备清空")]
        UnAuthByClearDevice = 170,
        /// <summary>
        /// 设备重置
        /// </summary>
        [Description("设备重置")]
        UnAuthByReSetDevice = 175,
        /// <summary>
        /// WebApi新增
        /// </summary>
        [Description("WebApi新增")]
        AuthByWebApiAdd = 180,
        /// <summary>
        /// 单设备单人员
        /// </summary>
        [Description("单设备单人员")]
        AuthByDeviceWorker = 185,
        /// <summary>
        /// APP授权人员
        /// </summary>
        [Description("APP授权人员")]
        AuthByAppWorker = 190,
        /// <summary>
        /// 自动匹配设备人员
        /// </summary>
        [Description("自动匹配人员")]
        AuthByAutoMatch = 195,
        #endregion

        #region PublicApi(设备接收考勤，人员新增删除通知)
        [Description("宇泛单双发PublicApi")]
        YfSingleDoublePublicApi = 300,
        [Description("宇泛单双发设备通知新增")]
        YfSingleDoubleDeviceAdd = 305,
        [Description("宇泛单双发设备通知删除")]
        YfSingleDoubleDeviceDel = 310,
        #endregion

        #region 查询并处理设备中人员(宇泛)
        [Description("查询设备中人员")]
        YfDevicePersonsQuery = 330,
        [Description("处理设备中人员")]
        YfDevicePersonsHandle = 335,
        #endregion

        #region 推送IoT数据到第三方平台
        [Description("推送IoT数据到余杭蓝宸平台")]
        PushIoTToYuHangLanChenPlatform = 340,  //余杭V1版
        [Description("推送IoT数据到余杭五色平台")]
        PushIoTToYuHangWuSePlatform = 341,  //余杭V2版
        [Description("推送IoT数据到省建工平台")]
        PushIoTToShengJianGongPlatform = 342,
        [Description("推送IoT数据到品茗桩桩平台")]
        PushIoTToPinMingZhuangZhuangPlatform = 343,
        [Description("推送IoT数据到平湖方欣平台")]
        PushIoTToPinHuFangXinPlatform = 344,
        [Description("推送IoT数据到运河辰祥平台")]
        PushIoTToYunHeChenXiangPlatform = 345,
        [Description("推送IoT数据到衢州方欣平台")]
        PushIoTToQuZhouFangXinPlatform = 346,
        [Description("推送IoT数据到润腾华润平台")]
        PushIoTToRunTengHuaRunPlatform = 347,
        [Description("推送IoT数据到广联达平台")]
        PushIoTToGuangLianDaPlatform = 348,
        #endregion
    }

    /// <summary>
    /// ComMq公共来源枚举类
    /// </summary>
    public enum ComMqSourceEnum
    {
        [Description("双发设备PublicApi通知新增或删除")]
        SingleDoubleAddOrDel = 10,
        [Description("WEB劳务网站")]
        WebAddOrDel = 11,
        [Description("单双发设备PublicApi考勤上传")]
        SingleDoubleAttendance = 13,
        [Description("Mqtt服务收到设备上线下线")]
        MqttServerOnOffLine = 15,
        [Description("WEB劳务网站")]
        WebSetConfig = 20,
        [Description("WebApi")]
        WebApi = 25,
        [Description("WebApp")]
        WebApp = 30,
        [Description("数据中心服务")]
        DataCenter = 35,
        [Description("任务调度服务")]
        DataServices = 40,
        [Description("Iot数据接收V1")]
        IotDataReceiverV1 = 45,
        [Description("Iot数据接收V2")]
        IotDataReceiverV2 = 46,
    }
}
