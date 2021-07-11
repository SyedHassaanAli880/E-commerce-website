using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.ViewModel.Category
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Is Active")]
        public int IsActive { get; set; }
    }
}
