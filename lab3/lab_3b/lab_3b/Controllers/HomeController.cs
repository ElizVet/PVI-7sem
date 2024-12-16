using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab_3b.Controllers
{
	public class HomeController : Controller
	{
		ApplicationDbContext context;
		UserManager<IdentityUser> userManager;
		RoleManager<IdentityRole> roleManager;

		public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.context = context;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			if (HttpContext.User.Identity?.Name != null)
			{
                var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
				ViewBag.user = user;

				var userRolesIds = context.UserRoles
					.Where(r => r.UserId == user.Id)
					.Select(r => r.RoleId).ToList();

				string userRolesString = "";
				foreach (var roleId in userRolesIds)
				{
					var role = await roleManager.FindByIdAsync(roleId);
					userRolesString += $"{role.Name}, ";
				}

				if (userRolesString.Length > 2)
				{
					userRolesString = userRolesString.Remove(userRolesString.Length - 2);
				}

				ViewBag.userRoles = userRolesString;
			}
			else
			{
				ViewBag.user = null;
				ViewBag.role = null;
			}
			return View();
		}
	}
}
