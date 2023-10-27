using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    /// <summary>
    /// 业务类别：1设备，2设备人员，4照片，8授权，16参建单位，32班组，64工人,128进退场，256进退场2，512自动退场 
    /// </summary>
    public enum BaseBizTypeEnum
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
        自动退场 = 512
    }
}
