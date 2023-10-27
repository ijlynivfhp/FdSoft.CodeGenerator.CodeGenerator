using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base
{
    public class BaseResponse<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PageResponseData<T>? data { get; set; } = new PageResponseData<T>();

        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; } = "";

    }


    public class PageResponseData<T> where T : class, new()
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount { get; set; }

        /// <summary>
        /// 指定页号，以 0 为起始数字，表示 第 1 页
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页记录数，最多不能超过 50
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int totalCount { get; set; }


        public List<T>? rows { get; set; } = new List<T>();

    }
}
