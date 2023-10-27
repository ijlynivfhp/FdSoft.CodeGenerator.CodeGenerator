using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 角色信息，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_Role")]
    public class JCRole
    {
        /// <summary>
        /// 描述 :角色主键 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int RoleId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 描述 :角色状态,0为正常. 
        /// 空值 : true  
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ItemPath { get; set; }

        /// <summary>
        /// 描述 :角色名 
        /// 空值 : true  
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string PowerCode { get; set; }

        /// <summary>
        /// 描述 :0：全局角色 1：非全局角色(后期企业有自建角色时，全局的就可见可选) 
        /// 空值 : true  
        /// </summary>
        public int? RoleType { get; set; }

        /// <summary>
        /// 描述 :节点类型，用于分组,默认0，1为分组（文件夹） 
        /// 空值 : true  
        /// </summary>
        public int? NodeType { get; set; }

        /// <summary>
        /// 描述 :所属产品ID 
        /// 空值 : true  
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string Remark { get; set; }

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
        public string LastEditor { get; set; }

        /// <summary>
        /// 描述 :记录创建人姓名 
        /// 空值 : true  
        /// </summary>
        public string Creator { get; set; }

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