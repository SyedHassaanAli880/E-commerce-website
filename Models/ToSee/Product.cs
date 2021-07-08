using System.ComponentModel.DataAnnotations;

namespace BethinyShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public string ImageUrl { get; set; }

        //public string ImageThumbnailUrl { get; set; }

        [Required]
        [Display(Name = "Is In Stock?")]
        public bool IsInStock { get; set; }

        [Required]
        [Display(Name = "Quantity" )]
        public long quantity { get; set; }

        //[Required]
        [Display(Name = "Choose Image")]
        public string ImagePhoto { get; set; }
    }

   
}
