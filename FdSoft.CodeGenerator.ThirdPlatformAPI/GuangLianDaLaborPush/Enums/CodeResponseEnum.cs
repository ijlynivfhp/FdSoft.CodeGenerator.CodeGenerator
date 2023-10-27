using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums
{
    /// <summary>
    /// 返回编码
    /// </summary>
    public enum eCode
    {
        成功或重复上传 = 0,
        请求方式错误 = -1,
        无api访问权限 = -2,
        必填字段为空或检验失败 = -3,
        未找到错误 = -4,
        参数不正确 = 40,
        签名错误 = 41,
        请求频繁 = 42,
        请求超过最大次数 = 43,
        其他 = 44,
    }
}
