using Trails4Health.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Data {
    public class UsersSeedData {
        // 5. (b.d.AUTENTICAÇÃO) 
        // este metodo vai ser chamado no controlador AcountController.cs
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager) {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
            // se não encontra admin na tabela users que foi criada automaticamente
            if (admin == null) {
                admin = new ApplicationUser { UserName = adminName };
                // cria registo com adminName e adminPass
                await userManager.CreateAsync(admin, adminPass);
            }
        }
    }
}
