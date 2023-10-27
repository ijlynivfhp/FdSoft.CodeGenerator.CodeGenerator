using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 项目信息，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_Project")]
    public class JCProject
    {
        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string ProId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ProNo { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ProName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ProSmallName { get; set; }

        /// <summary>
        /// 描述 :1在建 2竣工 
        /// 空值 : true  
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 描述 :1正常，2停工整改 
        /// 空值 : true  
        /// </summary>
        public int? ActiveStatus { get; set; }

        /// <summary>
        /// 描述 :形象进度 
        /// 空值 : true  
        /// </summary>
        public string Progress { get; set; }

        /// <summary>
        /// 描述 :项目子类别 
        /// 空值 : true  
        /// </summary>
        public string ProSubType { get; set; }

        /// <summary>
        /// 描述 :项目类别1：房建项目，2：市政项目 
        /// 空值 : true  
        /// </summary>
        public int? ProType { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 描述 :中标编号 
        /// 空值 : true  
        /// </summary>
        public string TenderNum { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string RegNumber { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public DateTime? RegDate { get; set; }

        /// <summary>
        /// 描述 :工程地址 
        /// 空值 : true  
        /// </summary>
        public string ProAddress { get; set; }

        /// <summary>
        /// 描述 :施工许可证号 
        /// 空值 : true  
        /// </summary>
        public string ShigongCerNo { get; set; }

        /// <summary>
        /// 描述 :工程造价（万元） 
        /// 空值 : true  
        /// </summary>
        public decimal ProPrice { get; set; }

        /// <summary>
        /// 描述 :工资性工程款 
        /// 空值 : true  
        /// </summary>
        public decimal ProSalaryCost { get; set; }

        /// <summary>
        /// 描述 :开始时间 
        /// 空值 : true  
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 描述 :结束时间 
        /// 空值 : true  
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 描述 :建筑高度 
        /// 空值 : true  
        /// </summary>
        public decimal ProjectHeight { get; set; }

        /// <summary>
        /// 描述 :层数 
        /// 空值 : true  
        /// </summary>
        public int? ProjectFloor { get; set; }

        /// <summary>
        /// 描述 :格式1,2 表示地上1层，地下2层 
        /// 空值 : true  
        /// </summary>
        public string ProjectFloorInfo { get; set; }

        /// <summary>
        /// 描述 :建筑面积 
        /// 空值 : true  
        /// </summary>
        public decimal ProjectArea { get; set; }

        /// <summary>
        /// 描述 :地上面积,地下面积 
        /// 空值 : true  
        /// </summary>
        public string ProjectAreaInfo { get; set; }

        /// <summary>
        /// 描述 :结构类型 
        /// 空值 : true  
        /// </summary>
        public string ProjectStruct { get; set; }

        /// <summary>
        /// 描述 :开户行 
        /// 空值 : true  
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string MapPos { get; set; }

        /// <summary>
        /// 描述 :同步类型（复选值，3=1+2），1全国，2品茗 
        /// 空值 : true  
        /// </summary>
        public int? SyncType { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ShigongUnitCorpCode { get; set; }

        /// <summary>
        /// 描述 :施工单位 
        /// 空值 : true  
        /// </summary>
        public string ShigongUnitName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string JianLiUnitCorpCode { get; set; }

        /// <summary>
        /// 描述 :监理单位 
        /// 空值 : true  
        /// </summary>
        public string JianLiUnitName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ConsUnitCorpCode { get; set; }

        /// <summary>
        /// 描述 :建设单位 
        /// 空值 : true  
        /// </summary>
        public string ConsUnitName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string DesignUnitCorpCode { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string DesignUnitName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string KanchaUnitCorpCode { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string KanchaUnitName { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ProManager { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string JsonData { get; set; }

        /// <summary>
        /// 描述 :授权状态 
        /// 空值 : true  
        /// </summary>
        public int? AuthStatus { get; set; }

        /// <summary>
        /// 描述 :授权到期时间 
        /// 空值 : true  
        /// </summary>
        public DateTime? AuthEndDate { get; set; }

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
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? DeleteStatus { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? AddTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? UpdateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ProjectCode { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ExtPK1 { get; set; }

        /// <summary>
        /// 描述 :子系统显示与否，复合值，目前仅用于企业云平台1.   0或者null为正常 
        /// 空值 : true  
        /// </summary>
        public int? HideStatus { get; set; }



    }
}