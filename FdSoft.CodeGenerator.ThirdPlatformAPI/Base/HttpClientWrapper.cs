using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Base
{
    public class HttpClientWrapper
    {
        public HttpClient HttpClient { get; set; }

        public mApiToken ApiToken { get; set; }

        public bool CallBackSetFlag { get; set; }

        public bool TokeIllegalFlag { get; set; }

        public HttpClientWrapper()
        {

        }
        public HttpClientWrapper(HttpClient client)
        {
            HttpClient = client;
        }
    }
}
