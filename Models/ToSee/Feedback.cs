using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        
        [Required(ErrorMessage = "Your email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Feedback is required.")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }

        public class FeedbackMap
        {
            public FeedbackMap(EntityTypeBuilder<Feedback> entityTypeBuilder)
            {
                //entityTypeBuilder.HasKey(x => x.FeedbackID);
                entityTypeBuilder.Property(x => x.Name).HasMaxLength(100);
                entityTypeBuilder.Property(x => x.Message).IsRequired();
                entityTypeBuilder.Property(x => x.Email).IsRequired();
            }
        }
    }
}
