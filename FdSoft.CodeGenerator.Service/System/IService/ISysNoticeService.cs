using System;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.System.IService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author fdsoft.codegenerator
    /// @date 2021-12-15
    /// </summary>
    public interface ISysNoticeService: IBaseService<SysNotice>
    {
        List<SysNotice> GetSysNotices();
    }
}
