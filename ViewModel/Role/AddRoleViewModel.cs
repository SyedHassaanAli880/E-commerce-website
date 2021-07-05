using System.ComponentModel.DataAnnotations;

namespace BethinyShop.ViewModel
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
