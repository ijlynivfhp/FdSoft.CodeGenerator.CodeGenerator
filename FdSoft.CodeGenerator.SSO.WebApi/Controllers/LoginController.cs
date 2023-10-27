using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Model.System.Dto;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Service.System;
using FdSoft.CodeGenerator.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FdSoft.CodeGenerator.Service.System.IService;
using Hei.Captcha;
using Microsoft.Extensions.Options;
using IPTools.Core;
using UAParser;
using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Common.Enums;
using FdSoft.CodeGenerator.Common.Model;
using Microsoft.AspNetCore.Authorization;
using FdSoft.CodeGenerator.Service.Base.IBaseService;
using JinianNet.JNTemplate.Dynamic;
using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Common.Cache;
using FdSoft.CodeGenerator.Model.Dto.Base;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Core.Framework;
using FdSoft.CodeGenerator.Core.Extensions;
using FdSoft.CodeGenerator.Core.Filters;
using Mapster;
using System.Diagnostics;
using Newtonsoft.Json;

namespace FdSoft.CodeGenerator.SSO.WebApi.Controllers
{
    public class LoginController : BaseController
    {
        static readonly NLog.Logger logger = NLog.LogManager.GetLogger("LoginController");
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISysUserService sysUserService;
        private readonly ISysMenuService sysMenuService;
        private readonly ISysLoginService sysLoginService;
        private readonly ISysPermissionService permissionService;
        private readonly SecurityCodeHelper SecurityCodeHelper;
        private readonly ISysConfigService sysConfigService;
        private readonly ISysRoleService roleService;
        private readonly OptionsSetting jwtSettings;

        public LoginController(
            IHttpContextAccessor contextAccessor,
            ISysMenuService sysMenuService,
            ISysUserService sysUserService,
            ISysLoginService sysLoginService,
            ISysPermissionService permissionService,
            ISysConfigService configService,
            ISysRoleService sysRoleService,
            SecurityCodeHelper captcha,
            IOptions<OptionsSetting> jwtSettings)
        {
            httpContextAccessor = contextAccessor;
            SecurityCodeHelper = captcha;
            this.sysMenuService = sysMenuService;
            this.sysUserService = sysUserService;
            this.sysLoginService = sysLoginService;
            this.permissionService = permissionService;
            this.sysConfigService = configService;
            roleService = sysRoleService;
            this.jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// hello
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Ok("已经成功启动了本项目");
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="dtoNew">登录对象</param>
        /// <returns></returns>
        [Log(Title = "登录")]
        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody] LoginBodyDtoNew dtoNew)
        {
            //dtoNew.LoginIp = HttpContextExtension.GetClientUserIp(HttpContext);

            //var sysLogininfor = RecordLogInfo(httpContextAccessor.HttpContext);
            var sw = Stopwatch.StartNew();
            var switchToken = SwitchToken(dtoNew);
            sw.Stop();
            logger.Info($"登录（SwitchLogin）：耗时{sw.Elapsed.TotalMilliseconds}毫秒,用户信息：{JsonConvert.SerializeObject(switchToken)}");
            return switchToken;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="dtoNew">登录对象</param>
        /// <returns></returns>
        [Log(Title = "登录")]
        [HttpPost("SwitchProject")]
        [Verify]
        public IActionResult SwitchProject([FromBody] LoginBodyDtoNew dtoNew)
        {
            //dtoNew.LoginIp = HttpContextExtension.GetClientUserIp(HttpContext);

            //var sysLogininfor = RecordLogInfo(httpContextAccessor.HttpContext);
            dtoNew.UserId = HttpContext.GetUId().ParseToInt();
            var sw = Stopwatch.StartNew();
            var switchToken = SwitchToken(dtoNew);
            sw.Stop();
            logger.Info($"登录（SwitchProject）：耗时{sw.Elapsed.TotalMilliseconds}毫秒,用户信息：{JsonConvert.SerializeObject(switchToken)}");
            return switchToken;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="dtoNew">登录对象</param>
        /// <returns></returns>
        [Log(Title = "登录")]
        [HttpPost("SwitchProduct")]
        [Verify]
        public IActionResult SwitchProduct([FromBody] LoginBodyDtoNew dtoNew)
        {
            //dtoNew.LoginIp = HttpContextExtension.GetClientUserIp(HttpContext);

            //var sysLogininfor = RecordLogInfo(httpContextAccessor.HttpContext);
            dtoNew.UserId = HttpContext.GetUId().ParseToInt();
            var sw = Stopwatch.StartNew();
            var switchToken = SwitchToken(dtoNew);
            sw.Stop();
            logger.Info($"登录（SwitchProduct）：耗时{sw.Elapsed.TotalMilliseconds}毫秒,用户信息：{JsonConvert.SerializeObject(switchToken)}");
            return switchToken;
        }

        private IActionResult SwitchToken(LoginBodyDtoNew dtoNew)
        {
            try
            {
                var jCUser = sysLoginService.Login(dtoNew, out LoginUserExtDto loginUserExtDto);

                var loginUserDto = loginUserExtDto.Adapt<LoginUserDto>();
                loginUserDto.Token = loginUserExtDto.Token = JwtUtil.GenerateJwtToken(JwtUtil.AddClaimsNew(loginUserDto), jwtSettings.JwtSettings);
                //允许一个用户多点登录
                if (dtoNew.ClientId != Guid.Empty)
                    RedisHelper.Expire($"{GlobalConstant.FdSoftSSO}:{dtoNew.UserId}:{dtoNew.ClientId}", -1);

                //允许一个用户单点登录
                //var userLoginKeys = RedisHelper.Keys($"{GlobalConstant.Cache}:{GlobalConstant.FdSoft.CodeGeneratorSSO}:{dtoNew.UserId}:*");
                //foreach (var item in userLoginKeys) { 
                //    RedisHelper.Expire(item.Replace($"{GlobalConstant.Cache}:",default), -1);
                //};
                RedisHelper.Set($"{GlobalConstant.FdSoftSSO}:{jCUser.UserId}:{loginUserExtDto.ClientId}", loginUserExtDto, jwtSettings.JwtSettings.Expire * 60);
                //CacheService.SetUserPerms(GlobalConstant.LoginUser + jCUser.UserId, loginUserNew);
                return ToResponse(ApiResult.Success(loginUserDto));
            }
            catch (Exception ex)
            {
                return ToResponse(ApiResult.Error(ex.Message));
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [Log(Title = "注销")]
        [HttpPost("LogOutNew")]
        [Verify]
        public IActionResult LogOutNew(int userId)
        {
            //Task.Run(async () =>
            //{
            //    //注销登录的用户，相当于ASP.NET中的FormsAuthentication.SignOut  
            //    await HttpContext.SignOutAsync();
            //}).Wait();
            //var userid = HttpContext.GetUId();
            //var name = HttpContext.GetName();

            //CacheService.RemoveUserPerms(GlobalConstant.UserPermKEY + userid);
            if (userId == 0) return SUCCESS(default);
            return SUCCESS("注销成功");
        }




        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginBody">登录对象</param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        //[Log(Title = "登录")]
        public IActionResult Login([FromBody] LoginBodyDto loginBody)
        {
            if (loginBody == null) { throw new CustomException("请求参数错误"); }
            loginBody.LoginIP = HttpContextExtension.GetClientUserIp(HttpContext);
            SysConfig sysConfig = sysConfigService.GetSysConfigByKey("sys.account.captchaOnOff");
            if (sysConfig?.ConfigValue != "off" && CacheHelper.Get(loginBody.Uuid) is string str && !str.ToLower().Equals(loginBody.Code.ToLower()))
            {
                return ToResponse(ResultCode.CAPTCHA_ERROR, "验证码错误");
            }

            var user = sysLoginService.Login(loginBody, RecordLogInfo(httpContextAccessor.HttpContext));

            List<SysRole> roles = roleService.SelectUserRoleListByUserId(user.UserId);
            //权限集合 eg *:*:*,system:user:list
            List<string> permissions = permissionService.GetMenuPermission(user);

            LoginUser loginUser = new(user, roles, permissions);
            CacheService.SetUserPerms(GlobalConstant.UserPermKEY + user.UserId, permissions);
            return SUCCESS(JwtUtil.GenerateJwtToken(JwtUtil.AddClaims(loginUser), jwtSettings.JwtSettings));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [Log(Title = "注销")]
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            //Task.Run(async () =>
            //{
            //    //注销登录的用户，相当于ASP.NET中的FormsAuthentication.SignOut  
            //    await HttpContext.SignOutAsync();
            //}).Wait();
            var userid = HttpContext.GetUId();
            var name = HttpContext.GetName();

            CacheService.RemoveUserPerms(GlobalConstant.UserPermKEY + userid);
            return SUCCESS(new { name, id = userid });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [Verify]
        [HttpGet("getInfo")]
        public IActionResult GetUserInfo()
        {
            long userid = HttpContext.GetUId();
            var user = sysUserService.SelectUserById(userid);

            //前端校验按钮权限使用
            //角色集合 eg: admin,yunying,common
            List<string> roles = permissionService.GetRolePermission(user);
            //权限集合 eg *:*:*,system:user:list
            List<string> permissions = permissionService.GetMenuPermission(user);
            user.WelcomeContent = GlobalConstant.WelcomeMessages[new Random().Next(0, GlobalConstant.WelcomeMessages.Length)];
            return SUCCESS(new { user, roles, permissions });
        }

        /// <summary>
        /// 获取路由信息
        /// </summary>
        /// <returns></returns>
        [Verify]
        [HttpGet("getRouters")]
        public IActionResult GetRouters()
        {
            long uid = HttpContext.GetUId();
            var menus = sysMenuService.SelectMenuTreeByUserId(uid);

            return ToResponse(ToJson(1, sysMenuService.BuildMenus(menus)));
        }

        /// <summary>
        /// 生成图片验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("captchaImage")]
        public ApiResult CaptchaImage()
        {
            string uuid = Guid.NewGuid().ToString().Replace("-", "");

            SysConfig sysConfig = sysConfigService.GetSysConfigByKey("sys.account.captchaOnOff");
            var captchaOff = sysConfig?.ConfigValue ?? "0";

            var length = AppSettings.GetAppConfig<int>("CaptchaOptions:length", 4);
            var code = SecurityCodeHelper.GetRandomEnDigitalText(length);
            byte[] imgByte = GenerateCaptcha(captchaOff, code);
            string base64Str = Convert.ToBase64String(imgByte);
            CacheHelper.SetCache(uuid, code);
            var obj = new { uuid, img = base64Str };// File(stream, "image/png")

            return ToJson(1, obj);
        }

        /// <summary>
        /// 生成图片验证码
        /// </summary>
        /// <param name="captchaOff"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private byte[] GenerateCaptcha(string captchaOff, string code)
        {
            byte[] imgByte;
            if (captchaOff == "1")
            {
                imgByte = SecurityCodeHelper.GetGifEnDigitalCodeByte(code);//动态gif数字字母
            }
            else if (captchaOff == "2")
            {
                imgByte = SecurityCodeHelper.GetGifBubbleCodeByte(code);//动态gif泡泡
            }
            else if (captchaOff == "3")
            {
                imgByte = SecurityCodeHelper.GetBubbleCodeByte(code);//泡泡
            }
            else
            {
                imgByte = SecurityCodeHelper.GetEnDigitalCodeByte(code);//英文字母加数字
            }

            return imgByte;
        }

        /// <summary>
        /// 记录用户登陆信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public SysLogininfor RecordLogInfo(HttpContext context)
        {
            var ipAddr = context.GetClientUserIp();
            var ip_info = IpTool.Search(ipAddr);
            ClientInfo clientInfo = context.GetClientInfo();
            SysLogininfor sysLogininfor = new()
            {
                Browser = clientInfo?.Device?.Family,
                Os = Convert.ToString(clientInfo?.OS),
                Ipaddr = ipAddr,
                UserName = context.GetName(),
                LoginLocation = ip_info?.Province + "-" + ip_info?.City
            };

            return sysLogininfor;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("/register")]
        [AllowAnonymous]
        [Log(Title = "注册", BusinessType = Common.Enums.BusinessType.INSERT)]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            SysConfig config = sysConfigService.GetSysConfigByKey("sys.account.register");
            if (config?.ConfigValue != "true")
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "当前系统没有开启注册功能！");
            }
            SysConfig sysConfig = sysConfigService.GetSysConfigByKey("sys.account.captchaOnOff");
            if (sysConfig?.ConfigValue != "off" && CacheHelper.Get(dto.Uuid) is string str && !str.ToLower().Equals(dto.Code.ToLower()))
            {
                return ToResponse(ResultCode.CAPTCHA_ERROR, "验证码错误");
            }
            if (UserConstants.NOT_UNIQUE.Equals(sysUserService.CheckUserNameUnique(dto.Username)))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, $"保存用户{dto.Username}失败，注册账号已存在");
            }
            SysUser user = sysUserService.Register(dto);
            if (user.UserId > 0)
            {
                return SUCCESS(user);
            }
            return ToResponse(ResultCode.CUSTOM_ERROR, "注册失败，请联系管理员");
        }
    }
}
