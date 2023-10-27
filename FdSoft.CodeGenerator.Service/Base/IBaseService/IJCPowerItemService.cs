using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model.System.Vo;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Service.Base.IBaseService
{
    /// <summary>
    /// 角色菜单service接口
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    public interface IJCPowerItemService : IBaseService<JCPowerItem>
    {
        public List<SysMenu> GetPowerItemTreeData(List<JCPowerItem> baseAllList);

        PagedInfo<JCPowerItem> GetList(JCPowerItemQueryDto parm);

        int AddJCPowerItem(JCPowerItem parm);

        int UpdateJCPowerItem(JCPowerItem parm);
        
        void TruncateJCPowerItem();
    }
}
