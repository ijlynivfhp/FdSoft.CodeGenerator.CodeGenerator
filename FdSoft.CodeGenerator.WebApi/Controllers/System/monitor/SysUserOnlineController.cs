using Microsoft.AspNetCore.Mvc;
using FdSoft.CodeGenerator.WebApi.Filters;

namespace FdSoft.CodeGenerator.WebApi.Controllers.monitor
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
