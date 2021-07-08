using System.ComponentModel.DataAnnotations;

namespace BethinyShop.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter username")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
