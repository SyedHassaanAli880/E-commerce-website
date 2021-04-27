using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Models
{
    public class Feedback
    {
        [BindNever]
        public int FeedbackID { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "Your name is required.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Feedback is required.")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
