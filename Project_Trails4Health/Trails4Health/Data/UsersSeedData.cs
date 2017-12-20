<<<<<<< HEAD
﻿using Trails4Health.Models;
using Microsoft.AspNetCore.Identity;
=======
﻿using Microsoft.AspNetCore.Identity;
>>>>>>> f52a3b07c1f4a8c87e1513fda6f9a3e0d6a08516
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace Trails4Health.Data {
    public class UsersSeedData {
        // 5. (b.d.AUTENTICAÇÃO) 
        // este metodo vai ser chamado no controlador AcountController.cs
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager) {
=======
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager)
        {
>>>>>>> f52a3b07c1f4a8c87e1513fda6f9a3e0d6a08516
            const string adminName = "Admin";
            const string adminPass = "Secret123$";

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
<<<<<<< HEAD
            // se não encontra admin na tabela users que foi criada automaticamente
            if (admin == null) {
                admin = new ApplicationUser { UserName = adminName };
                // cria registo com adminName e adminPass
=======
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminName };
>>>>>>> f52a3b07c1f4a8c87e1513fda6f9a3e0d6a08516
                await userManager.CreateAsync(admin, adminPass);
            }
        }
    }
}
