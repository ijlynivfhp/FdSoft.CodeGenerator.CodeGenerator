using FdSoft.CodeGenerator.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model
{
    public class BasePo
    {
        public string Keyword { get; set; }

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
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名,必须是手机号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 是否企业
        /// </summary>
        public bool IsCompany { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string TrueName { get; set; }

        ///// <summary>
        ///// 是否管理员
        ///// </summary>
        //public bool IsAdmin { get; set; }

        ///// <summary>
        ///// 产品Id
        ///// </summary>
        //public int productId { get; set; }

        ///// <summary>
        ///// 登录产品公司或项目
        ///// </summary>
        //public JCCorporation Corp { get; set; }

        ///// <summary>
        ///// 用户登录Token
        ///// </summary>
        //public string Token { get; set; }
    }
}
