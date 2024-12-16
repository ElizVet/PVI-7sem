using Microsoft.AspNetCore.Identity;

namespace Lab3b.Helpers
{
    public static class AdminUserSeeder
    {
        public static async Task SeedAdminUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminUserName = "admin";
            string adminPassword = "P@ssw0rd";
            string roleName = "Administrator";

            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var adminUser = await userManager.FindByNameAsync(adminUserName);

            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminUserName, Email = adminUserName };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, roleName);
            }
        }
    }
}
