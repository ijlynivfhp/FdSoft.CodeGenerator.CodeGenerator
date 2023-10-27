using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 用户角色关联表输入对象
    /// </summary>
    public class JCUserRoleDto
    {
        [Required(ErrorMessage = "不能为空")]
        public int UrId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public int CoId { get; set; }
        public int? CreateUserId { get; set; }
        public int? LastEditUserId { get; set; }
        public string LastEditor { get; set; }
        public string Creator { get; set; }
        public int? DeleteStatus { get; set; }
        public int? AddTime { get; set; }
        public int? UpdateTime { get; set; }
    }

    /// <summary>
    /// 用户角色关联表查询对象
    /// </summary>
    public class JCUserRoleQueryDto : PagerInfo 
    {
    }
}
