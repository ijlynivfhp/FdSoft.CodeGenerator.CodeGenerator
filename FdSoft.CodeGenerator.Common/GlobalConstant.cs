using System;
using System.Collections.Generic;
using System.Text;

namespace FdSoft.CodeGenerator.Common
{
    /// <summary>
    /// 全局静态常量
    /// </summary>
    public class GlobalConstant
    {
        /// <summary>
        /// 管理员权限
        /// </summary>
        public static string AdminPerm = "*:*:*";
        /// <summary>
        /// 管理员角色
        /// </summary>
        public static string AdminRole = "admin";
        /// <summary>
        /// 开发版本API映射路径
        /// </summary>
        public static string DevApiProxy = "/dev-api/";
        /// <summary>
        /// 用户权限缓存key
        /// </summary>
        public static string UserPermKEY = "CACHE-USER-PERM";

        /// <summary>
        /// 用户权限缓存key
        /// </summary>
        public static string FdSoftSSO = "FdSoftSSO";

        #region 缓存前缀
        /// <summary>
        /// 缓存前缀
        /// </summary>
        public const string Cache = @"cache";
        #endregion

        #region 缓存常量
        public const string Cache_YingShiYunApi_Token = Cache + "_YingShiYunApi_Token";
        #endregion

        #region 全表缓存
        /// <summary>
        /// 全表缓存
        /// </summary>
        public static string AllTable = @"AllTable";
        #endregion

        #region Redis缓存前缀
        /// <summary>
        /// 推送劳务数据到广联达系统（相同项目不同接口推送频率不低于1秒）
        /// </summary>
        public const string PushLaborDataToGuangLianDaLock = "PushLaborDataToGuangLianDaLock:";
        #endregion

        /// <summary>
        /// 欢迎语
        /// </summary>
        public static string[] WelcomeMessages = new string[] {
            "祝你开心每一天！",
            "忙碌了一周，停一停脚步！",
            "世间美好，与你环环相扣！",
            "永远相信美好的事情即将发生！",
            "每一天，遇见更好的自己！",
            "保持热爱，奔赴山海！",
            "生活明朗，万物可爱！",
            "愿每一天醒来都是美好的开始！",
            "没有希望的地方，就没有奋斗！",
            "我最珍贵的时光都行走在路上！",
            "成功，往往住在失败的隔壁！",
            "人只要不失去方向，就不会失去自己！",
            "每条堵住的路，都有一个出口！",
            "没有谁能击垮你，除非你自甘堕落！",
            "微笑着的人并非没有痛苦！",
            "生活变的再糟糕，也不妨碍我变得更好！",
            "你要悄悄努力，然后惊艳众人！",
            "人与人之间最大的信任是精诚相见",
            "人生就像爬坡，要一步一步来。",
            "今天的目标完成了吗？",
            "高效工作，告别996",
            "销售是从别人拒绝开始的！"
        };

        #region 项目
        public const string Material = "Material";
        public const string SSO = "SSO";
        public const string PublicApi = "PublicApi";
        public const string DataCenter = "DataCenter";
        #endregion

        #region 产品
        public const int MaterialByPro = 3001;
        public const int MaterialByCor = 3002;
        public const int LaborByPro = 2;
        #endregion

        #region 单双发业务相关
        /// <summary>
        /// 单双发设备编号前缀
        /// </summary>
        public const string DevicePre = "Uface_";
        /// <summary>
        /// 单双发设备默认端口号
        /// </summary>
        public const string SingleDoublePort = "8090";
        /// <summary>
        /// 单双发设备配置宇泛Url
        /// </summary>
        public const string SingleDoublePinMinUrl = "http://115.233.209.232:9018/sbzlDevice/api/task/action";
        /// <summary>
        /// 单双发设备配置宇泛端口
        /// </summary>
        public const string SingleDoublePinMinPort = "9018";
        /// <summary>
        /// 单双发设备配置宇泛Tcp
        /// </summary>
        public const string SingleDoublePinMinTcp = "115.233.209.232";

        /// <summary>
        /// 考勤记录分库前缀
        /// </summary>
        public const string AttendanceRecordConn = "ConnectionStrings:conn_db_attendance_record";

        /// <summary>
        /// IoTSys分库
        /// </summary>
        public const string IoTSysConn = "ConnectionStrings:conn_db_iotsys";

        /// <summary>
        /// 凡东考勤保留一个月
        /// </summary>
        public const string FindongAttendanceCopy = "findong-attendance-copy";

        /// <summary>
        /// 单双发考勤备份
        /// </summary>
        public const string SingleDoubleCopy = "SingleDoubleCopy";

        /// <summary>
        /// 默认考勤备份
        /// </summary>
        public const string DefalutCopy = "DefalutCopy";

        /// <summary>
        /// 杭州黑色Base64头像
        /// </summary>
        public const string BlackHeadImgBase64 = "data:image/bmp;base64,/9j/4AAQSkZJRgABAQEB9AH0AAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAB+AGYDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD5/ooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAP/9k=";

        /// <summary>
        /// 杭州黑色HTTP头像
        /// </summary>
        public const string HZBlackHeadImgHttp = "081132929-4506.bmp";
        #endregion

        #region 分布式锁
        public const string AddWorkerAndPwWorkerLock = "AddWorkerAndPwWorkerLock:";

        public const string AddAuthorityLock = "AddAuthorityLock:";
        #endregion

        /// <summary>
        /// 超级管理员角色类型
        /// </summary>
        public const int SuperRoleType = 9999;

        /// <summary>
        /// 杭州接口并发访问异常信息
        /// </summary>
        public const string HzResponseConcurrentError = "此接口不允许并发访问";

        #region 设备相关
        //单双发设备新增人员，删除标记会话Id
        public const string AddWithDelMsgId = "AddWithDelMsgId";

        //单双发设备清空人员，清空标记会话Id
        public const string ClearMsgId = "ClearMsgId";

        //单双发设备重置，重置标记会话Id
        public const string ReSetMsgId = "ReSetMsgId";

        //单双发设备已存在提示信息
        public const string ExistMsg = "照片ID已存在，请先调用删除或更新接口";

        //单双发设备新增人员，删除忽略处理（定时查询处理设备）标记会话Id
        public const string AutoHandleMsgId = "AutoHandleMsgId";
        #endregion

        #region 域名相关
        public const string LaborWebApi = "http://labor.api.findong.com";
        #endregion
    }
}
