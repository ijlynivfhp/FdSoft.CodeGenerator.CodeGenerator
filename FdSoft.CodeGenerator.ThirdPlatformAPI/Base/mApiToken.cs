using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Base
{
    public class mApiToken
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }

        public int TokenType { get; set; }
    }
}
