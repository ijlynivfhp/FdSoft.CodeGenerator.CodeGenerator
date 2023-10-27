using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 用户表输入对象
    /// </summary>
    public class JCUserDto
    {
        [Required(ErrorMessage = "用户主键不能为空")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string TrueName { get; set; }
        public int? Status { get; set; }
        public string Sex { get; set; }
        public string IDCard { get; set; }
        public string Email { get; set; }
        public string TelePhone { get; set; }
        public string CertNo { get; set; }
        public int? TelePhoneVerifyStatus { get; set; }
        public DateTime? LastLoginTimeNow { get; set; }
        public DateTime? LastLoginTimePre { get; set; }
        public string LastLoginIPNow { get; set; }
        public string LastLoginIPPre { get; set; }
        public int? LoginCount { get; set; }
        public int? RootCoId { get; set; }
        public string ProId { get; set; }
        public int? ProductId { get; set; }
        public int? RoleId { get; set; }
        public int? CreateUserId { get; set; }
        public int? LastEditUserId { get; set; }
        public string Creator { get; set; }
        public string LastEditor { get; set; }
        public int? DeleteStatus { get; set; }
        public int? AddTime { get; set; }
        public int? UpdateTime { get; set; }
    }

    /// <summary>
    /// 用户表查询对象
    /// </summary>
    public class JCUserQueryDto : PagerInfo 
    {
    }
}
