using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using Newtonsoft.Json;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request
{
    /// <summary>
    /// 1.2.2新增和修改班组信息
    /// </summary>
    public class TeamGroupRequest : BaseRequest
    {
        [JsonIgnore]
        public TeamGroup Body { get; set; } = new TeamGroup();

        public class TeamGroup
        {
            /// <summary>
            /// string 是 企业统一社会信用代码
            /// </summary>
            public string companyCode { get; set; }

            /// <summary>
            /// string 是 班组名称，项目下唯一
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// string 是 班组长姓名，如果没有该参数，统一填：默认班组长
            /// </summary>
            public string leaderName { get; set; } = "默认班组长";

            /// <summary>
            /// string 否 班组长身份证号
            /// </summary>
            public string leaderIdentification { get; set; }

            /// <summary>
            /// string 否 班组长联系电话
            /// </summary>
            public string leaderPhone { get; set; }

            /// <summary>
            /// int 是 班组类型，0：建筑工人班组，1：管理人员班组
            /// </summary>
            public int type { get; set; } = 0;

            /// <summary>
            /// Long 否 班组编码，班组上传成功返回的编码，新增班组不填，更新班组必填。
            /// </summary>
            public long? groupCode { get; set; }

            /// <summary>
            /// string 否 工种编码
            /// </summary>
            //public string workTypeCode { get; set; }
        }
    }
}
