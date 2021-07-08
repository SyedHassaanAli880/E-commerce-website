using BethinyShop.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        public bool UpdateProduct(int id, Product vari)
        {  
            var prod = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
            
            if (prod != null)
            {
                if (/*ModelState.IsValid*/true)
                {
                    //string uniqueFileName = null;

                    //if (vari.ImagePhoto != null)
                    //{
                    //    string uploadsfolder = Path.Combine(_env.WebRootPath, "images");

                    //    uniqueFileName = Guid.NewGuid().ToString() + "_" + vari.ImagePhoto.FileName;

                    //    string filePath = Path.Combine(uploadsfolder, uniqueFileName);

                    //    vari.ImagePhoto.CopyTo(new FileStream(filePath, FileMode.Create));

                    //}

                    Product p = new Product
                    {
                        Name = vari.Name,
                        ShortDescription = vari.ShortDescription,
                        LongDescription = vari.LongDescription,
                        Price = vari.Price,
                        IsInStock = vari.IsInStock,
                        quantity = vari.quantity,
                        //ImagePhoto = uniqueFileName
                    };

                    return true;
                }
            }


            return false;
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
