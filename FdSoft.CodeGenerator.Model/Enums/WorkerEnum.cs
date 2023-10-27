using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    public enum eWorkerDataSource
    {
        未知 = 0,
        App = 1,
        Web = 2,
        杭州平台 = 3,
        第三方推送 = 4
    }

    /// <summary>
    /// 动态判断与杭州交互工人来源归属
    /// </summary>
    public enum eWorkerDataSourceExt
    {
        无 = 0,
        凡东 = 1,
        杭州 = 2
    }

    /// <summary>
    /// projectWorker表进退场状态
    /// </summary>
    public enum eProjectWorkerJoinStatus
    { 
        入场=1,
        退场=0
    }
}
