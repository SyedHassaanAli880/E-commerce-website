using BethinyShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Models
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        public Product GetProductById(int prodId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == prodId);
        }

        public int AddProduct(Product vari)
        {
            _appDbContext.Products.Add(vari);

            int x = _appDbContext.SaveChanges();

            return x;
        }

        public bool DeleteProduct(int ID)
        {
            var prod = _appDbContext.Products.FirstOrDefault(x=>x.Id == ID);
            
            if(prod != null)
            {
                _appDbContext.Remove(prod);

                _appDbContext.SaveChanges();

                return true;
            }
            

            return false;
        }
    }
}
