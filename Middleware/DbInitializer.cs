using EmployeePortal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace EmployeePortal.Middleware
{
    public static class DbInitializer
    {
        public static async Task SeedSuperuserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string superuserEmail, string superuserPassword)
        {
            var superuser = await userManager.FindByEmailAsync(superuserEmail);

            if (superuser == null)
            {
                superuser = new ApplicationUser { FirstName = "superuser", LastName = "superuser", UserName = superuserEmail, Email = superuserEmail };
                var result = await userManager.CreateAsync(superuser, superuserPassword);

                if (result.Succeeded)
                {
                    // Assign roles to the user.
                    if (!await roleManager.RoleExistsAsync("Superuser"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Superuser"));
                    }
                    await userManager.AddToRoleAsync(superuser, "Superuser");
                }
            }
        }
    }
}


