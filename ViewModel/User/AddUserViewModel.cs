using System;
using System.ComponentModel.DataAnnotations;

namespace BethinyShop.ViewModel
{
    public class AddUserViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
