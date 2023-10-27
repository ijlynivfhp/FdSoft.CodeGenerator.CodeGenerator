using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 企业、项目信息表，包含关联层级输入对象
    /// </summary>
    public class JCCorporationDto
    {
        [Required(ErrorMessage = "不能为空")]
        public int CoId { get; set; }
        public int? ParentCoId { get; set; }
        public int? RootCoId { get; set; }
        public string ItemPath { get; set; }
        public int? Status { get; set; }
        public int? CoType { get; set; }
        public string CoName { get; set; }
        public string CorpCode { get; set; }
        public string AreaCode { get; set; }
        public string ProId { get; set; }
        public string ContactMan { get; set; }
        public string ContactManTel { get; set; }
        public string LegalMan { get; set; }
        public string LegalManTel { get; set; }
        public string UnitLevel { get; set; }
        public string UnitPhone { get; set; }
        public string Fax { get; set; }
        public string WebUrl { get; set; }
        public string Address { get; set; }
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
    /// 企业、项目信息表，包含关联层级查询对象
    /// </summary>
    public class JCCorporationQueryDto : PagerInfo 
    {
    }
}
