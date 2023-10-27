using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Dto.Business
{
    public class SingleDoubleMqttGetDto<T>
    {
        public string msgId { get; set; }
        public string method { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
        public long timestamp { get; set; }
        public string msg { get; set; }
    }
}
