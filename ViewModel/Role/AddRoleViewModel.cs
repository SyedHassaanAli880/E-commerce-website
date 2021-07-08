using System.ComponentModel.DataAnnotations;

namespace BethinyShop.ViewModel
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "Please add a role!")]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
