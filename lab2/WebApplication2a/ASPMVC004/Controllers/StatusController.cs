using Microsoft.AspNetCore.Mvc;

namespace ASPMVC004.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult S200()
        {
            return Ok();
        }
        public IActionResult S300()
        {
            return Redirect("https://learn.microsoft.com/");
            //return StatusCode(301);
        }
        public int S500()
        {
            int dividend = 10;
            int divisor = 0;
            return dividend / divisor;
        }

    }
}
