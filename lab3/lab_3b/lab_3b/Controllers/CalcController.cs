using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace lab_3b.Controllers
{
	public class CalcController : Controller
	{
		[HttpGet, Authorize(Roles = "Employee,Master")]
		public ViewResult Index()
		{
			return View("Calc");
		}

		[Authorize(Roles = "Employee,Master")]
		public ViewResult Sum(float? x, float? y)
		{
			ViewBag.press = "+";

			SetXAndY(x, y);

			if (x != null && y != null) ViewBag.z = x + y;
			else ViewBag.z = 0;

			return View("Calc");
		}

		[Authorize(Roles = "Employee,Master")]
		public ViewResult Sub(float? x, float? y)
		{
			ViewBag.press = "-";

			SetXAndY(x, y);

			if (x != null && y != null) ViewBag.z = x - y;
			else ViewBag.z = 0;

			return View("Calc");
		}

		[Authorize(Roles = "Employee,Master")]
		public ViewResult Mul(float? x, float? y)
		{
			ViewBag.press = "*";

			SetXAndY(x, y);

			if (x != null && y != null) ViewBag.z = x * y;
			else ViewBag.z = 0;

			return View("Calc");
		}

		[Authorize(Roles = "Employee,Master")]
		public ViewResult Div(float? x, float? y)
		{
			ViewBag.press = "/";

			SetXAndY(x, y);

			if (x == 0 && y == 0)
			{
				ViewBag.z = 0;
			}
			else if (x != null && y != null)
			{
				float z = (float)x / (float)y;
				ViewBag.z = z;
			}
			else ViewBag.z = 0;

			return View("Calc");
		}

		[NonAction]
		private void SetXAndY(float? x, float? y)
		{
			if (x != null) ViewBag.x = x;
			else
			{
				ViewBag.x = 0;
				if (Request.Method == "POST")
				{
					ViewBag.Error = "-- ERROR --";
				}
			}

			if (y != null) ViewBag.y = y;
			else
			{
				ViewBag.y = 0;
				if (Request.Method == "POST")
				{
					ViewBag.Error = "-- ERROR --";
				}
			}
		}
	}
}
