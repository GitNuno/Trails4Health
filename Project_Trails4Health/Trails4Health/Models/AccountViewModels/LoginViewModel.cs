using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.AccountViewModels
{
    public class LoginViewModel
    {
        // 7. (b.d.AUTENTICAÇÃO)
        [Required]
<<<<<<< HEAD
        // [EmailAddress] Email passa a ser admin: para não estar sujeito ás regras de [EmailAddress]
=======
        //[EmailAddress]
>>>>>>> f52a3b07c1f4a8c87e1513fda6f9a3e0d6a08516
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}// correr aplicação
 // ver BooksController.cs
