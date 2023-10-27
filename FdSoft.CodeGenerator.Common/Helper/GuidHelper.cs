using SequentialGuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public class GuidHelper
    {
        public static Guid GetGuid()
        {
            return SequentialGuidGenerator.Instance.NewGuid();
        }
    }
}
