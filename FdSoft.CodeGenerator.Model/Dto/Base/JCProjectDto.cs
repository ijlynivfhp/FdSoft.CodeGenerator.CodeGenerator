using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FdSoft.CodeGenerator.Model.Dto;
using FdSoft.CodeGenerator.Model.Models;

namespace FdSoft.CodeGenerator.Model.Dto
{
    /// <summary>
    /// 项目信息输入对象
    /// </summary>
    public class JCProjectDto
    {
        [Required(ErrorMessage = "不能为空")]
        public string ProId { get; set; }
        public string ProNo { get; set; }
        public string ProName { get; set; }
        public string ProSmallName { get; set; }
        public int? Status { get; set; }
        public int? ActiveStatus { get; set; }
        public string Progress { get; set; }
        public string ProSubType { get; set; }
        public int? ProType { get; set; }
        public string AreaCode { get; set; }
        public string TenderNum { get; set; }
        public string RegNumber { get; set; }
        public DateTime? RegDate { get; set; }
        public string ProAddress { get; set; }
        public string ShigongCerNo { get; set; }
        public decimal ProPrice { get; set; }
        public decimal ProSalaryCost { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ProjectHeight { get; set; }
        public int? ProjectFloor { get; set; }
        public string ProjectFloorInfo { get; set; }
        public decimal ProjectArea { get; set; }
        public string ProjectAreaInfo { get; set; }
        public string ProjectStruct { get; set; }
        public string Bank { get; set; }
        public string MapPos { get; set; }
        public int? SyncType { get; set; }
        public string ShigongUnitCorpCode { get; set; }
        public string ShigongUnitName { get; set; }
        public string JianLiUnitCorpCode { get; set; }
        public string JianLiUnitName { get; set; }
        public string ConsUnitCorpCode { get; set; }
        public string ConsUnitName { get; set; }
        public string DesignUnitCorpCode { get; set; }
        public string DesignUnitName { get; set; }
        public string KanchaUnitCorpCode { get; set; }
        public string KanchaUnitName { get; set; }
        public string ProManager { get; set; }
        public string JsonData { get; set; }
        public int? AuthStatus { get; set; }
        public DateTime? AuthEndDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? LastEditUserId { get; set; }
        public string LastEditor { get; set; }
        public string Creator { get; set; }
        public int? DeleteStatus { get; set; }
        public int? AddTime { get; set; }
        public int? UpdateTime { get; set; }
        public string ProjectCode { get; set; }
        public string ExtPK1 { get; set; }
        public int? HideStatus { get; set; }
    }

    /// <summary>
    /// 项目信息查询对象
    /// </summary>
    public class JCProjectQueryDto : PagerInfo 
    {
    }
}
