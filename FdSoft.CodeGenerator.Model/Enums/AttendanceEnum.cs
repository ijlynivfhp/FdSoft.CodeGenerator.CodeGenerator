using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    public enum AttendanceTypeEnum
    {
        项目考勤统计 = 1,
        /// <summary>
        /// 根据ProId按月、日聚合考勤次数
        /// </summary>
        项目考勤分析 = 2,
        /// <summary>
        /// 根据CoId按月、日聚合考勤次数
        /// </summary>
        企业考勤分析 = 3,
        /// <summary>
        /// 根据PwId按月聚合考勤次数
        /// </summary>
        项目工人考勤统计 = 4,
        /// <summary>
        /// 按项目维度基础数据汇总统计
        /// </summary>
        项目维度基础考勤统计 = 200,
        /// <summary>
        /// 人员考勤_项目考勤统计
        /// </summary>
        人员考勤_项目考勤统计 = 201,
    }

    public enum AttendanceSubTypeEnum
    {
        默认 = 0,
        施工单位汇总 = 1,
        施工单位作业人员 = 2,
        施工单位项目经理 = 3,
        施工单位管理人员 = 4,
        监理单位总监理工程师 = 5,
        监理单位管理人员 = 6,
        建设单位管理人员 = 7,
        其他单位方管理人员 = 8,
    }

    public enum EarlyWarnByProEnum
    {
        考勤预警 = 1
    }
    public enum EarlyWarnByProSubEnum
    {
        红色预警 = 1,
        黄色预警 = 2
    }

    public enum EarlyWarnByWorkerEnum
    {
        长期未考勤 = 1
    }

    public enum EarlyWarnByWorkerSubEnum
    {

    }

    public enum BizTypeEarlyWarnByWorkerEnum
    {
        长期未考勤 = 1,
        考勤预警 = 2,
        登记预警 = 100,
        在岗预警 = 200
    }

    public enum BizSubTypeEarlyWarnByWorkerEnum
    {
        [Description("黑名单")]
        登记预警_黑名单 = 101,
        [Description("不良记录")]
        登记预警_不良记录 = 102,
        [Description("年龄不符")]
        登记预警_年龄不符 = 103,
        [Description("身份证过期")]
        登记预警_身份证过期 = 104,
        [Description("黑名单")]
        在岗预警_黑名单 = 201,
        [Description("不良记录")]
        在岗预警_不良记录 = 202,
        [Description("年龄不符")]
        在岗预警_年龄不符 = 203,
        [Description("资格证过期")]
        在岗预警_资格证过期 = 204,

    }

    /// <summary>
    /// 考勤数据来源
    /// 存储在分库分表DataSource字段中
    /// </summary>
    public enum eDBAttendanceSourceEnum
    {
        [Description("其他")]
        设备不存在 = -1,
        [Description("其他")]
        工人不存在 = -2,
        [Description("其他")]
        设备工人不存在 = -3,
        [Description("其他")]
        设备类型有误 = -4,
        [Description("其他")]
        设备不存在并且退场在考勤 = -5,
        [Description("其他")]
        退场在考勤 = -6,

        [Description("其他")]
        设备不存在Api = -21,
        [Description("其他")]
        工人不存在Api = -22,
        [Description("其他")]
        设备工人不存在Api = -23,

        [Description("其他")]
        设备不存在宇泛V1 = -24,
        [Description("其他")]
        工人不存在宇泛V1 = -25,

        [Description("其他")]
        设备不存在宇泛V2 = -26,
        [Description("其他")]
        工人不存在宇泛V2 = -27,

        [Description("其他")]
        工人不存在宇泛离线 = -28,

        [Description("其他")]
        设备不存在杭州 = -29,
        [Description("其他")]
        工人不存在杭州刷脸 = -30,
        [Description("其他")]
        工人不存在杭州扫码 = -31,
        [Description("其他")]
        设备工人不存在杭州 = -32,
        [Description("其他")]

        设备不存在海青 = -33,
        [Description("其他")]
        工人不存在海青 = -34,

        [Description("其他")]
        异常不可修复 = -100,
        [Description("其他")]
        其他人脸设备 = 1,

        [Description("双发")]
        人脸设备刷脸海青直发 = 2998,
        [Description("单发")]
        人脸设备刷脸宇泛海思单发 = 2996,
        [Description("双发")]
        人脸设备刷脸宇泛海思双发 = 2997,
        [Description("双发")]
        人脸设备刷脸宇泛海思双发定制 = 2995,
        [Description("单发")]
        人脸设备刷脸宇泛海思沃 = 3000,
        [Description("单发")]
        人脸设备刷脸宇泛安卓沃土 = 2999,
        [Description("离线")]
        人脸设备刷脸宇泛离线 = 2994,
        [Description("直发")]
        人脸设备刷脸宇泛直发 = 2993,

        [Description("其他")]
        客服补录单个 = 2001,
        [Description("其他")]
        客服补录批量 = 2002,
        [Description("其他")]
        App打卡 = 2003,

        [Description("杭州刷脸考勤")]
        第三方平台拉取杭州刷脸 = 3001,
        [Description("杭州扫码考勤")]
        第三方平台拉取杭州扫码 = 3002,
        [Description("湖州刷脸考勤")]
        第三方平台拉取湖州刷脸 = 3003,

        [Description("其他")]
        第三方平台推送 = 4000,
        [Description("其他")]
        第三方平台推送宁波姜太公 = 4001,
    }

    public enum FdServiceTypeEnum
    {
        默认 = 0,
        考勤业务 = 10
    }

    public enum FdServiceSubTypeEnum
    {
        默认 = 0,

        #region 考勤业务
        身份证号不存在 = 10,
        项目拉取配置不存在 = 15,
        考勤拉取密钥无效 = 20,
        杭州拉取失败 = 25,
        工人不存 = 30,
        杭州拉取异常 = 35,

        #endregion
    }
}
