using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 企业、项目信息表，包含关联层级，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_Corporation")]
    public class JCCorporation
    {
        /// <summary>
        /// 描述 : 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int CoId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? ParentCoId { get; set; }

        /// <summary>
        /// 描述 :所属根组织ID（单位ID） 
        /// 空值 : true  
        /// </summary>
        public int? RootCoId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ItemPath { get; set; }

        /// <summary>
        /// 描述 :0正常，1锁定 
        /// 空值 : true  
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 描述 :0组织（公司），1项目部，2子组织（子公司） 
        /// 空值 : true  
        /// </summary>
        public int? CoType { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string CoName { get; set; }

        /// <summary>
        /// 描述 :参建企业统一社会信用代码
 
        /// 空值 : true  
        /// </summary>
        public string CorpCode { get; set; }

        /// <summary>
        /// 描述 :注册地区 
        /// 空值 : true  
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 描述 :如果是项目部，proid对应项目表 
        /// 空值 : true  
        /// </summary>
        public string ProId { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ContactMan { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string ContactManTel { get; set; }

        /// <summary>
        /// 描述 :法人代表 
        /// 空值 : true  
        /// </summary>
        public string LegalMan { get; set; }

        /// <summary>
        /// 描述 :法人电话 
        /// 空值 : true  
        /// </summary>
        public string LegalManTel { get; set; }

        /// <summary>
        /// 描述 :资质等级 
        /// 空值 : true  
        /// </summary>
        public string UnitLevel { get; set; }

        /// <summary>
        /// 描述 :单位电话 
        /// 空值 : true  
        /// </summary>
        public string UnitPhone { get; set; }

        /// <summary>
        /// 描述 :传真号 
        /// 空值 : true  
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 描述 :组织机构网址 
        /// 空值 : true  
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 描述 :备注信息 
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
        /// 描述 :0正常，1删除 
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
        /// 子菜单
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<JCCorporation> Children { get; set; } = new List<JCCorporation>();

    }
}