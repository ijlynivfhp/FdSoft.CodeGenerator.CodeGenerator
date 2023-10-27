﻿using Infrastructure.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.Model.System;

namespace FdSoft.CodeGenerator.Repository.System
{
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class SysTasksQzRepository: BaseRepository<SysTasksQz>
    {
    }
}
