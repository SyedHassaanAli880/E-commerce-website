using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if(!context.Products.Any())
            {
                context.AddRange
               (
                new Product { Id = 1, Name = "Apple Pie", Price = 12.59M, ShortDescription = "Short desc 1", LongDescription = "Long desc 1" },
                new Product { Id = 2, Name = "Blue berry", Price = 18.59M, ShortDescription = "Short desc 2", LongDescription = "Long desc 2"},
                new Product { Id = 3, Name = "Cheese Cake", Price = 17.59M, ShortDescription = "Short desc 3", LongDescription = "Long desc 3"},
                new Product { Id = 4, Name = "Cherry Pie", Price = 15.59M, ShortDescription = "Short desc 4", LongDescription = "Long desc 4"}
               );

                context.SaveChanges();
            }
        }
    }
}
