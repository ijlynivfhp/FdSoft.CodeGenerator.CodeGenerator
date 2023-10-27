using System;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;
using System.Collections.Generic;

namespace FdSoft.CodeGenerator.Service.Business.IBusinessService
{
    /// <summary>
    /// 演示service接口
    ///
    /// @author zz
    /// @date 2022-03-31
    /// </summary>
    public interface IGenDemoService : IBaseService<GenDemo>
    {
        PagedInfo<GenDemo> GetList(GenDemoQueryDto parm);

    }
}
