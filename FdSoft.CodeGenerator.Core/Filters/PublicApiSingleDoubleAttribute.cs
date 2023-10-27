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
using Microsoft.AspNetCore.Http;
using FdSoft.CodeGenerator.Common.Extensions;
using System.Security.Policy;
using FdSoft.CodeGenerator.Model.Enums;
using Newtonsoft.Json;
using FdSoft.CodeGenerator.Common.Helper;

namespace FdSoft.CodeGenerator.Core.Filters
{
    /// <summary>
    /// 授权校验访问
    /// 如果跳过授权登录在Action 或controller加上 AllowAnonymousAttribute
    /// </summary>
    public class PublicApiSingleDoubleAttribute : Attribute, IAuthorizationFilter
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// PublicApi接口较验
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

            var msg = ResultCode.FORBIDDEN.GetDescription();
            var appKey = context.HttpContext.Request.Query["appKey"].FirstOrDefault();
            var appSecret = context.HttpContext.Request.Query["appSecret"].FirstOrDefault();
            if (!string.IsNullOrEmpty(appKey) && !string.IsNullOrEmpty(appSecret) && CommonHelper.IoTPwdMD5(appKey.ParseToGuid(), SyncTypeEnum.宇泛海思单双发.GetDescription()) == appSecret)
                return;
            NLogHelper.Error($"项目：{appKey}_密钥不正确！");
            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(new { result = 0, success = false })
            };
            //string ip = HttpContextExtension.GetClientUserIp(context.HttpContext);
            //string url = context.HttpContext.Request.Path;
            //var isAuthed = context.HttpContext.User.Identity.IsAuthenticated;

            //var token = context.HttpContext.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, "token不能为空！")); return;
            //}

            //var claimList = JwtUtil.ParseTokenNew(token,out string error);

            //if(!string.IsNullOrEmpty(error))
            //{
            //    if (error.Contains("The token is expired")) error = "token已过期！";
            //    context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, error)); return;
            //}

            //var loginUserDto = JwtUtil.ValidateJwtTokenNew(claimList);
            //if (!isAuthed)
            //{
            //    context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, "鉴权失败！")); return;
            //}
            //if (loginUserDto is null)
            //{
            //    string msg = $"请求访问[{url}]失败，无法访问系统资源";
            //    logger.Info($"{msg}");
            //    context.Result = new JsonResult(new ApiResult((int)ResultCode.DENY, msg));
            //}
        }
    }
}
