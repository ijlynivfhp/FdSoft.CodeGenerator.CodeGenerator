using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums
{
    public enum CodeResponseEnum
    {
        成功 = 200,
        参数异常 = 500,
        签名校验失败 = 401,
        权限不足 = 403,
    }
}
