﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FdSoft.CodeGenerator.Model.System.Dto
{
    public class SysdictDataDto
    {
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        public List<SysDictData> List { get; set; }
    }
}
