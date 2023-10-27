using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace FdSoft.CodeGenerator.Model.Models
{
    /// <summary>
    /// 用户表，数据实体对象
    ///
    /// @author admin
    /// @date 2022-11-07
    /// </summary>
    [SugarTable("JC_User")]
    public class JCUser
    {
        /// <summary>
        /// 描述 :用户主键 
        /// 空值 : false  
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserId { get; set; }

        /// <summary>
        /// 描述 :用户名,必须是手机号 
        /// 空值 : true  
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 描述 :用户密码 
        /// 空值 : true  
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 描述 :真实姓名 
        /// 空值 : true  
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 描述 :0正常，1锁定 
        /// 空值 : true  
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 描述 :性别 
        /// 空值 : true  
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 描述 :身份证 
        /// 空值 : true  
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 描述 :Email 
        /// 空值 : true  
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 描述 :手机 
        /// 空值 : true  
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string CertNo { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? TelePhoneVerifyStatus { get; set; }

        /// <summary>
        /// 描述 :本次登陆时间 
        /// 空值 : true  
        /// </summary>
        public DateTime? LastLoginTimeNow { get; set; }

        /// <summary>
        /// 描述 :上次登陆时间 
        /// 空值 : true  
        /// </summary>
        public DateTime? LastLoginTimePre { get; set; }

        /// <summary>
        /// 描述 :本次登陆IP 
        /// 空值 : true  
        /// </summary>
        public string LastLoginIPNow { get; set; }

        /// <summary>
        /// 描述 :上次登陆IP 
        /// 空值 : true  
        /// </summary>
        public string LastLoginIPPre { get; set; }

        /// <summary>
        /// 描述 :登录次数 
        /// 空值 : true  
        /// </summary>
        public int? LoginCount { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public int? RootCoId { get; set; }

        /// <summary>
        /// 描述 :上次登录项目 
        /// 空值 : true  
        /// </summary>
        public string ProId { get; set; }

        /// <summary>
        /// 描述 :上次选择产品 
        /// 空值 : true  
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// 描述 :上次选择角色 
        /// 空值 : true  
        /// </summary>
        public int? RoleId { get; set; }

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
        public string Creator { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 : true  
        /// </summary>
        public string LastEditor { get; set; }

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



    }
}