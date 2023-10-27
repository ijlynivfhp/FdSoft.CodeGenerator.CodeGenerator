using Microsoft.AspNetCore.Mvc;
using FdSoft.CodeGenerator.SSO.WebApi.Filters;

namespace FdSoft.CodeGenerator.SSO.WebApi.Controllers.monitor
{
    [Verify]
    [Route("monitor/online")]
    public class SysUserOnlineController : BaseController
    {
        [HttpGet("list")]
        public IActionResult Index()
        {
            return SUCCESS(null);
        }
    }
}
