using Gym.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Gym.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAndAdminUserAsync(IServiceProvider serviceProvider)
        {
            // Get RoleManager and UserManager services
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define the roles you want to seed
            string[] roleNames = { "Customer", "Coach", "Supervisor", "SeniorSupervisor" };

            // Create each role if it doesn't exist
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Optionally create a default admin user for SeniorSupervisor role.
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                // Use a strong password in production
                var result = await userManager.CreateAsync(adminUser, "P@ssword1!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "SeniorSupervisor");
                }
            }
        }
    }
}
