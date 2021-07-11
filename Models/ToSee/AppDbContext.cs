using BethinyShop.Auth;
using BethinyShop.Models.Category;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethinyShop.Models
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
    }
}
