using FdSoft.CodeGenerator.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FdSoft.CodeGenerator.Model.System.Dto
{
    public class LoginBodyDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

        /**
         * 验证码
         */
        public string Code { get; set; }

        /**
         * 唯一标识
         */
        public string Uuid { get; set; } = "";
        public string LoginIP { get; set; }
        /// <summary>
        /// 企业或项目主键CoId
        /// </summary>
        public int CoId { get; set; }
    }
    public class LoginBodyDtoNew
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 前产品Id
        /// </summary>
        public int FromProductId { get; set; }

        /// <summary>
        /// 后产品Id
        /// </summary>
        public int ToProductId { get; set; }

        /// <summary>
        /// 是否明文密码
        /// </summary>
        public bool IsPlaintext { get; set; } = true;
        /// <summary>
        /// 登录Ip
        /// </summary>
        public string LoginIp { get; set; }
        /// <summary>
        /// 企业或项目主键CoId
        /// </summary>
        public int CoId { get; set; }
        /// <summary>
        /// 切换类型（0：默认登录，1：切换项目，2：切换产品）
        /// </summary>
        public int SwitchType { get; set; }
        /// <summary>
        /// 产品分类（1旧版本，2新版本）
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// 验证码缓存Key
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 客户端标识 
        /// </summary>
        public Guid ClientId { get; set; }
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public JCUser User { get; set; }
    }
}
