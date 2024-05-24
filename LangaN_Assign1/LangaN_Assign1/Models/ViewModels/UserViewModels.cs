using System.ComponentModel.DataAnnotations;

namespace LangaN_Assign1.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]

        [UIHint("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [UIHint("password")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
