using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;

namespace ASPMVC07.Controllers
{
    [Route("it")]
    public class TAResearchController : Controller
    {
        [Route("{n:int}/{str}", Order = 1)] //:regex(\\d+)
        [HttpGet]
        public IActionResult M04(int n, string str)
        {
            return Content($"GET:M04:/{n}/{str}");
        }

        [Route("{b:bool}/{letters}")]
       
        [HttpGet, HttpPost]
        public IActionResult M05(bool b, string letters)
        {
            var httpMethod = ControllerContext.HttpContext.Request.Method;
            return Content($"{httpMethod}:M05:/{b}/{letters}");
        }

        [Route("{f:float}/{str:length(2, 5)}", Order = 2)] //:regex(\\d+\\.\\d+)
        [HttpGet, HttpDelete]
        public IActionResult M06(float f, string str)
        {
            var httpMethod = ControllerContext.HttpContext.Request.Method;
            return Content($"{httpMethod}:M06:/{f}/{str}");
        }

        [Route("{letters:length(3, 4)}/{n:int:range(100, 200)}")]
        [HttpPut]
        public IActionResult M07(string letters, int n)
        {
            return Content($"PUT:M07:/{letters}/{n}");
        }

        [Route("{mail:regex(^\\w+@\\w+\\.\\w+)}")]
        [HttpPost]
        public IActionResult M08(string mail)
        {
            return Content($"POST:M08:/{mail}");
        }
    }
}
