using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model
{
    public class ComIds:BasePo
    {
        public int id { get; set; } = default;
        public List<int> ids { get; set; } = new List<int>();

        public bool IsNull()
        {
            return id > 0 || ids.Count > 0 ? false : true;
        }
    }
}
