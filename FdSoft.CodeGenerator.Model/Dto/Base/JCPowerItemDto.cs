using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 角色菜单输入对象
    /// </summary>
    public class JCPowerItemDto
    {
        [Required(ErrorMessage = "不能为空")]
        public int ItemId { get; set; }
        public int? ParentId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string ItemPath { get; set; }
        public int? ItemType { get; set; }
        public int? InheritType { get; set; }
        public string ItemValue { get; set; }
        public int? ProductId { get; set; }
        public string ItemUrlLike { get; set; }
        public string PowerCode { get; set; }
        public int? OrderId { get; set; }
        public string ItemIcon1 { get; set; }
        public string ItemIcon2 { get; set; }
        public string ExtField1 { get; set; }
        public string ExtField2 { get; set; }
        public string ExtField3 { get; set; }
        public string ExtField4 { get; set; }
        public string ExtField5 { get; set; }
        public int? IsSuper { get; set; }
        public int? OpenType { get; set; }
        public string Remark { get; set; }
        public int? CreateUserId { get; set; }
        public int? LastEditUserId { get; set; }
        public string LastEditor { get; set; }
        public string Creator { get; set; }
        public int? DeleteStatus { get; set; }
        public int? AddTime { get; set; }
        public int? UpdateTime { get; set; }
    }

    /// <summary>
    /// 角色菜单查询对象
    /// </summary>
    public class JCPowerItemQueryDto : PagerInfo 
    {
    }
}
