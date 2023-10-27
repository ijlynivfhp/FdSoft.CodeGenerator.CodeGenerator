using System;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.System
{
    /// <summary>
    /// 参数配置service接口
    ///
    /// @author zhaorui
    /// @date 2021-09-29
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}
