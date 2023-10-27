using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    /// <summary>
    /// 人员资格证书类型
    /// </summary>
    public enum WorkerCredentialsType
    {
        [Description("安考证")]
        安考证 = 1,
        [Description("现场管理人员")]
        现场管理人员 = 2,
        [Description("特种作业证书")]
        特种作业证书 = 3
    }
}
