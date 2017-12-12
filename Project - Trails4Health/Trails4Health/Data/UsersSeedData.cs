using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager)
        {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminName };
                await userManager.CreateAsync(admin, adminPass);
            }
        }
    }
}
