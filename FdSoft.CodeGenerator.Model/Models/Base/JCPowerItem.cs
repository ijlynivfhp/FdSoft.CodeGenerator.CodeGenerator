using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 角色菜单，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_PowerItem")]
    public class JCPowerItem
    {
        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ItemId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 描述 :菜单名 
        /// 空值 : true  
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 描述 :全表唯一的值，编写代码时，用来进行逻辑判断的。值应形象，如addBeiAnItem,用户不可以更改 
        /// 空值 : true  
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 描述 :父子关系CODE 
        /// 空值 : true  
        /// </summary>
        public string ItemPath { get; set; }

        /// <summary>
        /// 描述 : 菜单=1,独元=4,操作=5,数据范围=6 
        /// 空值 : true  
        /// </summary>
        public int? ItemType { get; set; }

        /// <summary>
        /// 描述 :权限继承方式，主要用于控制数据范围继承限定；0或者null表示弱继承，1表示强继承 
        /// 空值 : true  
        /// </summary>
        public int? InheritType { get; set; }

        /// <summary>
        /// 描述 :菜单路径 
        /// 空值 : true  
        /// </summary>
        public string ItemValue { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// 描述 :路径特征值 
        /// 空值 : true  
        /// </summary>
        public string ItemUrlLike { get; set; }

        /// <summary>
        /// 描述 :权限项标识值 
        /// 空值 : true  
        /// </summary>
        public string PowerCode { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 : true  
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ItemIcon1 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ItemIcon2 { get; set; }

        /// <summary>
        /// 描述 :扩展字段1 
        /// 空值 : true  
        /// </summary>
        public string ExtField1 { get; set; }

        /// <summary>
        /// 描述 :扩展字段2 
        /// 空值 : true  
        /// </summary>
        public string ExtField2 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ExtField3 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ExtField4 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ExtField5 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? IsSuper { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? OpenType { get; set; }

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

        /// <summary>
        /// 子菜单
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<JCPowerItem> Children { get; set; } = new List<JCPowerItem>();

    }
}