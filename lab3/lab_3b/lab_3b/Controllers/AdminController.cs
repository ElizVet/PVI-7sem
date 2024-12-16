using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Xml.Linq;

namespace lab_3b.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        UserManager<IdentityUser> userManager;
		RoleManager<IdentityRole> roleManager;
        SignInManager<IdentityUser> signInManager;
        IPasswordHasher<IdentityUser> hasher;

        public AdminController(
            ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
			RoleManager<IdentityRole> roleManager,
			SignInManager<IdentityUser> signInManager,
		    IPasswordHasher<IdentityUser> hasher)
        {
            this.context = context;
            this.userManager = userManager;
			this.roleManager = roleManager;
			this.signInManager = signInManager;
            this.hasher = hasher;
		}

        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity?.Name != null)
			{
                var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                ViewBag.user = user;

				var userRolesIds = context.UserRoles.Where(r => r.UserId == user.Id).Select(r => r.RoleId).ToList();

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

            ViewBag.users = context.Users.ToList();
            ViewBag.roles = context.Roles.ToList();
            ViewBag.users_roles = context.UserRoles.ToList();
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register(string controller = "Admin", string action = "Register")
        {
			if (HttpContext.User.Identity?.Name != null)
			{
				return RedirectToAction("Index", "Home");
			}

			if (controller == "Admin" && action == "Register")
            {
                return View();
            }
            else if (controller != "" && action != "")
            {
                return RedirectToAction(action, controller);
			}
            else
            {
                return View();
            }
        }

        [HttpPost, AllowAnonymous]
		public IActionResult Register(string name, string pass, string controller = "Admin", string action = "SignIn")
        {
			NewUser(name, pass);
			return RedirectToAction(action, controller);
		}

		public async void NewUser(string name, string pass)
		{
			IdentityUser user = new IdentityUser { UserName = name };
			string passhash = hasher.HashPassword(user, pass);
			user.PasswordHash = passhash;
			await userManager.CreateAsync(user);
		}



        [HttpGet, AllowAnonymous]
		public IActionResult SignIn(string controller = "Admin", string action = "SignIn")
        {
			if (HttpContext.User.Identity?.Name != null)
			{
				return RedirectToAction("Index", "Home");
			}

			if (controller == "Admin" && action == "SignIn")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, AllowAnonymous]
		public async Task<IActionResult> SignIn(string name, string pass, string controller = "Home", string action = "Index")
		{
			IdentityUser user = await userManager.FindByNameAsync(name);
            if (user != null && await userManager.CheckPasswordAsync(user, pass))
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction(action, controller);
			}
            else
            {
                return View();
            }
		}

		[HttpGet, HttpPost, Authorize]
		public IActionResult SignOut(string controller = "Admin", string action = "SignOut")
		{
			if (controller == "Admin" && action == "SignOut" && Request.Method == "GET")
			{
				return View();
			}

			if (Request.Method == "POST" && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                signInManager.SignOutAsync();
            }
			else
			{
				return RedirectToAction("Error", "Admin", new { message = "Unauthorized" });
			}

			if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}



		[HttpGet, Authorize(Roles = "Administrator")]
		public IActionResult CreateUser(string controller = "Admin", string action = "CreateUser")
        {
			if (controller == "Admin" && action == "CreateUser")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize(Roles = "Administrator")]
		public IActionResult CreateUser(string name, string pass, string controller = "Admin", string action = "Index")
		{
			NewUser(name, pass);
			return RedirectToAction(action, controller);
		}



		[HttpGet, Authorize(Roles = "Administrator")]
		public IActionResult DeleteUser(string controller = "Admin", string action = "DeleteUser")
		{
			if (controller == "Admin" && action == "DeleteUser")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteUser(string name, string controller = "Admin", string action = "Index")
		{
			IdentityUser user = await userManager.FindByNameAsync(name);
			if (user != null)
			{
				await userManager.DeleteAsync(user);
			}
			else
			{
				return RedirectToAction("Error", "Admin", new { message = "User doesn't exist" });
			}
			return RedirectToAction(action, controller);
		}



		[HttpPost, Authorize]
		public async Task<IActionResult> DeleteSelf()
		{
			if (HttpContext.User.Identity?.Name != null)
			{
				var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

				await signInManager.SignOutAsync();
				await userManager.DeleteAsync(user);
			}
			return View("SelfDeleted");
		}



		[HttpGet, Authorize(Roles = "Administrator")]
		public IActionResult CreateRole(string controller = "Admin", string action = "CreateRole")
		{
			if (controller == "Admin" && action == "CreateRole")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize(Roles = "Administrator")]
		public async Task<IActionResult> CreateRole(string name, string controller = "Admin", string action = "Index")
		{
			IdentityRole role = new IdentityRole(name);
			await roleManager.CreateAsync(role);
			return RedirectToAction(action, controller);
		}



		[HttpGet, Authorize(Roles = "Administrator")]
		public IActionResult DeleteRole(string controller = "Admin", string action = "DeleteRole")
		{
			if (controller == "Admin" && action == "DeleteRole")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteRole(string name, string controller = "Admin", string action = "Index")
		{
			IdentityRole role = await roleManager.FindByNameAsync(name);
			if (role != null)
			{
				await roleManager.DeleteAsync(role);
			}
			else
			{
				return RedirectToAction("Error", "Admin", new { message = "Role does not exist" });
			}
			return RedirectToAction(action, controller);
		}



		[HttpGet, Authorize(Roles = "Administrator")]
		public IActionResult Assign(string controller = "Admin", string action = "Assign")
		{
			if (controller == "Admin" && action == "Assign")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Assign(string userName, string roleName, string controller = "Admin", string action = "Assign")
		{
			IdentityUser user = await userManager.FindByNameAsync(userName);
			IdentityRole role = await roleManager.FindByNameAsync(roleName);
			if (user == null)
			{
				return RedirectToAction("Error", "Admin", new { message = "User does not exist" });
			}
			else if (role == null)
			{
				return RedirectToAction("Error", "Admin", new { message = "Role does not exist" });
			}
			else
			{
				await userManager.AddToRoleAsync(user, roleName);
			}
			return RedirectToAction(action, controller);
		}



		[HttpGet, Authorize]
		public IActionResult ChangePassword(string controller = "Admin", string action = "ChangePassword")
		{
			if (controller == "Admin" && action == "ChangePassword")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}

		[HttpPost, Authorize]
		public async Task<IActionResult> ChangePassword(string oldPass, string newPass, string controller = "Home", string action = "Index")
		{
			var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
			var result = await userManager.ChangePasswordAsync(user, oldPass, newPass);
			if (!result.Succeeded)
			{
				return RedirectToAction("Error", "Admin", new { message = result.Errors.First().Description });
			}
			return RedirectToAction(action, controller);
		}



		[HttpGet]
		public IActionResult Error(string message, string controller = "Admin", string action = "Error")
		{
			ViewBag.message = message;
			if (controller == "Admin" && action == "Error")
			{
				return View();
			}
			else if (controller != "" && action != "")
			{
				return RedirectToAction(action, controller);
			}
			else
			{
				return View();
			}
		}
	}
}
