using BethinyShop.Models;
using BethinyShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int prodId);

        int AddProduct(Product vari);

        bool UpdateProduct(int id, Product vari);

        bool DeleteProduct(int ID);
    }
}
