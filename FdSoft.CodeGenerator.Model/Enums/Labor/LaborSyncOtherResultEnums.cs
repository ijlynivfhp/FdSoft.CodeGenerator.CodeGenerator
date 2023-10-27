using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    /// <summary>
    /// 同步业务种类
    /// </summary>
    public enum SyncBizTypeEnum
    {
        设备 = 1,
        设备人员 = 2,
        照片 = 4,
        授权 = 8,
        参建单位 = 16,
        班组 = 32,
        工人 = 64,
        进退场 = 128,
        进退场2 = 256,
        自动退场 = 512,
    }

    public enum JoinQuitHistoryDataSource
    { 
        未知=0,
        凡东=1,
        杭州品茗=2,
        补录=3
    }
    public enum HistoryJoinOutEnum
    {
        进场 = 1,
        退场 = 2
    }

}
