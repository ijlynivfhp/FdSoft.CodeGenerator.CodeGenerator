using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 角色信息输入对象
    /// </summary>
    public class JCRoleDto
    {
        [Required(ErrorMessage = "角色主键不能为空")]
        public int RoleId { get; set; }
        public int? ParentId { get; set; }
        public int? Status { get; set; }
        public string ItemPath { get; set; }
        public string RoleName { get; set; }
        public string PowerCode { get; set; }
        public int? RoleType { get; set; }
        public int? NodeType { get; set; }
        public int? ProductId { get; set; }
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
    /// 角色信息查询对象
    /// </summary>
    public class JCRoleQueryDto : PagerInfo 
    {
    }
}
