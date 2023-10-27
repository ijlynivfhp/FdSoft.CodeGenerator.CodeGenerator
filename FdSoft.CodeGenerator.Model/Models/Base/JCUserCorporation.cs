using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 企业项目用户关联信息，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_UserCorporation")]
    public class JCUserCorporation
    {
        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UcId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        public int CoId { get; set; }

        /// <summary>
        /// 描述 :所属根组织ID（单位ID） 
        /// 空值 : true  
        /// </summary>
        public int? RootCoId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? CreateUserId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? LastEditUserId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string LastEditor { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? DeleteStatus { get; set; }

        /// <summary>
        /// 描述 :添加时间 
        /// 空值 : true  
        /// </summary>
        public int? AddTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? UpdateTime { get; set; }



    }
}