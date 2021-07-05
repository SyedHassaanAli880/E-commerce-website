using BethinyShop.Models;
using BethinyShop.ViewModel;
using BethinyShop.ViewModel.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BethinyShop.Controllers
{
    public class ProductManagementController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IHostingEnvironment _env;

        private readonly AppDbContext _db;

        public ProductManagementController(IProductRepository productRepository, UserManager<IdentityUser> um, AppDbContext apdb, IHostingEnvironment env)
        {
            _productRepository = productRepository;

            _userManager = um;

            _db = apdb;

            _env = env;
        }

        public IActionResult HomeListOfProducts()
        {
            var pproducts = _productRepository.GetAllProducts().OrderBy(p => p.Name);

            var obj = new ProductViewModel()
            {
                Title = "Product Shop",

                Products = pproducts.ToList()
            };

            return View(obj);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel vari)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if(vari.ImagePhoto != null)
                {
                    string uploadsfolder = Path.Combine(_env.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() +"_"+vari.ImagePhoto.FileName;
                    
                    string filePath = Path.Combine(uploadsfolder,uniqueFileName);

                    vari.ImagePhoto.CopyTo(new FileStream(filePath,FileMode.Create));

                }

                Product p = new Product
                {
                    Name = vari.Name,
                    ShortDescription = vari.ShortDescription,
                    LongDescription = vari.LongDescription,
                    Price = vari.Price,
                    IsInStock = vari.IsInStock,
                    quantity = vari.quantity,
                    ImagePhoto = uniqueFileName
                };

                int x = _productRepository.AddProduct(p);

                if(x > 0)
                {
                    return RedirectToAction("HomeListOfProducts", "ProductManagement");
                }
                else
                {
                    return RedirectToAction("HomeListOfProducts", "ProductManagement");
                }

                
            }
            else
            {
                return RedirectToAction("HomeListOfProducts", "ProductManagement");
            }
           
        }

        [HttpPost]
        public IActionResult DeleteProduct(int ID)
        {
            bool result = _productRepository.DeleteProduct(ID);

            if(result)
            {
                return RedirectToAction("HomeListOfProducts", "ProductManagement");
            }
            else
            {
                return RedirectToAction("HomeListOfProducts", "ProductManagement");
            }
            
        }


    }
}
