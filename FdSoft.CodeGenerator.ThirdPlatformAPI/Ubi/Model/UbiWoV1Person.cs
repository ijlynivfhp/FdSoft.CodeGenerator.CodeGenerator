using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi.Model
{
    /// <summary>
    /// 沃平台海思设备V1版本工人查询接口
    /// </summary>
    public class UbiWoV1Person
    {
        public int result { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public UbiWoV1PersonData data { get; set; }
    }

    public class UbiWoV1PersonData
    {
        public int total { get; set; }
        public List<UbiWoV1PersonContent> content { get; set; }
    }

    public class UbiWoV1PersonContent
    {
        public string guid { get; set; }
        public string tag { get; set; }
        public List<UbiWoV1PersonFace> faces { get; set; }
    }

    public class UbiWoV1PersonFace
    {
        public string guid { get; set; }
        public string faceUrl { get; set; }
        public string personGuid { get; set; }
    }

    public class UbiWoV2Person
    {
        public int result { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public bool success { get; set; }
        public UbiWoV2PersonData data { get; set; }

        public class UbiWoV2PersonData
        {
            public int total { get; set; }
            public List<UbiWoV2PersonContent> content { get; set; }
            public int index { get; set; }
            public int length { get; set; }
            public int size { get; set; }
            public class UbiWoV2PersonContent
            {
                public string admitGuid { get; set; }
                public string idCardNo { get; set; }
                public string phone { get; set; }
                public string name { get; set; }
            }
        }
    }
}
