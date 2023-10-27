using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Linq;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Core.Extensions;
using FdSoft.CodeGenerator.Core.Framework;

namespace FdSoft.CodeGenerator.Core.Filters
{
    /// <summary>
    /// 授权校验访问
    /// 如果跳过授权登录在Action 或controller加上 AllowAnonymousAttribute
    /// </summary>
    public class VerifyAttribute : Attribute, IAuthorizationFilter
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 只判断token是否正确，不判断权限
        /// 如果需要判断权限的在Action上加上ApiActionPermission属性标识权限类别，ActionPermissionFilter作权限处理
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var noNeedCheck = false;
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                noNeedCheck = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                  .Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
            }

            if (noNeedCheck) return;

            string ip = HttpContextExtension.GetClientUserIp(context.HttpContext);
            string url = context.HttpContext.Request.Path;
            var isAuthed = context.HttpContext.User.Identity.IsAuthenticated;

            var token = context.HttpContext.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, "token不能为空！")); return;
            }

            var claimList = JwtUtil.ParseTokenNew(token,out string error);

            if(!string.IsNullOrEmpty(error))
            {
                if (error.Contains("The token is expired")) error = "token已过期！";
                context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, error)); return;
            }

            var loginUserDto = JwtUtil.ValidateJwtTokenNew(claimList);
            if (!isAuthed)
            {
                context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, "鉴权失败！")); return;
            }
            if (loginUserDto is null)
            {
                string msg = $"请求访问[{url}]失败，无法访问系统资源";
                logger.Info($"{msg}");
                context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, msg));
            }
        }
    }
}
