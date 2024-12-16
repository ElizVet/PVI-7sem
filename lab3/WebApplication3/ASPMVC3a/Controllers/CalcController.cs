using Microsoft.AspNetCore.Mvc;

namespace ASPMVC3a.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
		public IActionResult Index(string? press, float? x, float? y)
		{
            ViewBag.Press = press;
            ViewBag.x = x;
            ViewBag.y = y;

            return View("Calc");
        }

        [HttpPost]
        public IActionResult Sum(float? x, float? y)
        {
            if (x.HasValue && y.HasValue)
            {
                ViewBag.x = (float)x;
                ViewBag.y = (float)y;
                ViewBag.z = x + y;
            }
            else
            {
                ViewBag.x = 0.0f;
                ViewBag.y = 0.0f;
                ViewBag.z = 0.0f;
                ViewBag.Error = "--ERROR--";
            }
            ViewBag.press = "+";

            return View("Calc");
        }

        [HttpPost]
        public IActionResult Sub(float? x, float? y)
        {
            if (x.HasValue && y.HasValue)
            {
                ViewBag.x = (float)x;
                ViewBag.y = (float)y;
                ViewBag.z = x - y;
            }
            else
            {
                ViewBag.x = 0.0f;
                ViewBag.y = 0.0f;
                ViewBag.z = 0.0f;
                ViewBag.Error = "--ERROR--";
            }
            ViewBag.press = "-";

            return View("Calc");
        }

        [HttpPost]
        public IActionResult Mul(float? x, float? y)
        {
            if (x.HasValue && y.HasValue)
            {
                ViewBag.x = (float)x;
                ViewBag.y = (float)y;
                ViewBag.z = x * y;
            }
            else
            {
                ViewBag.x = 0.0f;
                ViewBag.y = 0.0f;
                ViewBag.z = 0.0f;
                ViewBag.Error = "--ERROR--";
            }
            ViewBag.press = "*";

            return View("Calc");
        }

        [HttpPost]
        public IActionResult Div(float? x, float? y)
        {
            if (x.HasValue && y.HasValue)
            {
                ViewBag.x = (float)x;
                ViewBag.y = (float)y;
                ViewBag.z = x / y;
            }
            else
            {
                ViewBag.x = 0.0f;
                ViewBag.y = 0.0f;
                ViewBag.z = 0.0f;
                ViewBag.Error = "--ERROR--";
            }
            ViewBag.press = "/";

            return View("Calc");
        }
    }
}
