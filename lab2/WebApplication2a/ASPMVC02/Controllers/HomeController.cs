using Microsoft.AspNetCore.Mvc;

namespace ASPMVC02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("http://localhost:5069/Index.html");
        }
    }
}
