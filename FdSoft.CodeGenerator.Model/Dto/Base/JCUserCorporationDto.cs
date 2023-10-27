using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 企业项目用户关联信息输入对象
    /// </summary>
    public class JCUserCorporationDto
    {
        [Required(ErrorMessage = "不能为空")]
        public int UcId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public int CoId { get; set; }
        public int? RootCoId { get; set; }
        public int? CreateUserId { get; set; }
        public int? LastEditUserId { get; set; }
        public string Creator { get; set; }
        public string LastEditor { get; set; }
        public int? DeleteStatus { get; set; }
        public int? AddTime { get; set; }
        public int? UpdateTime { get; set; }
    }

    /// <summary>
    /// 企业项目用户关联信息查询对象
    /// </summary>
    public class JCUserCorporationQueryDto : PagerInfo 
    {
    }
}
