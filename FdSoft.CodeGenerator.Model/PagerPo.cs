using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model
{
    public class PagerPo : PagerInfo
    {
        /// <summary>
        /// 企业CoId
        /// </summary>
        public int CoId { get; set; }

        /// <summary>
        /// 企业根目录RootCoId
        /// </summary>
        public int RootCoId { get; set; }

        /// <summary>
        /// 项目ProId
        /// </summary>
        public string ProId { get; set; }

        /// <summary>
        /// 项目ProIds集合
        /// </summary>
        public List<string> ProIds { get; set; } = new List<string>();

        /// <summary>
        /// 是否企业
        /// </summary>
        public bool IsCompany { get; set; }
    }
}
