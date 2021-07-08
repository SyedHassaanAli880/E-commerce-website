using BethinyShop.Models;
using BethinyShop.Repositories.Interfaces;
using BethinyShop.ViewModel;
using BethinyShop.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Controllers
{
    //[Authorize(Roles = "Administrators")]
    //[Authorize(Policy = "DeleteProduct")]
    //[Authorize(Policy = "AddPie")]
    public class ProductManagementController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly Interface<Product> _repository;

        private readonly AppDbContext _appdbcontext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IHostingEnvironment _env;

        private readonly AppDbContext _db;

        public ProductManagementController(IProductRepository productRepository, UserManager<IdentityUser> um, AppDbContext apdb, IHostingEnvironment env, Interface<Product> Repository, AppDbContext appDbContext)
        {
            _productRepository = productRepository;

            _userManager = um;

            _db = apdb;

            _env = env;

            _repository = Repository;

            _appdbcontext = appDbContext;
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

        [HttpGet]
        public IActionResult EditProductDetails(int id)
        {
            var product =  _repository.GetById(id);

            if (product == null) return RedirectToAction("HomeListOfProducts","ProductManagement");

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProductDetails(int id ,Product vari, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                Product prod = _appdbcontext.Products.Where(x=>x.Id == id).FirstOrDefault();

                if (prod == null) return NotFound();

                try
                {
                    if (file != null)
                    {
                        string filename = System.Guid.NewGuid().ToString() + ".jpg";

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyToAsync(stream);
                        }

                        prod.Name = vari.Name;
                        prod.IsInStock = vari.IsInStock;
                        prod.LongDescription = vari.LongDescription;
                        prod.ShortDescription = vari.ShortDescription;
                        prod.Price = vari.Price;
                        prod.quantity = vari.quantity;
                        prod.ImagePhoto = filename;
                        _appdbcontext.SaveChanges();
                        return RedirectToAction("HomeListOfProducts", "ProductManagement");

                    }
                    else
                    {

                        prod.Name = vari.Name;
                        prod.IsInStock = vari.IsInStock;
                        prod.LongDescription = vari.LongDescription;
                        prod.ShortDescription = vari.ShortDescription;
                        prod.Price = vari.Price;
                        prod.quantity = vari.quantity;
                        prod.ImagePhoto = vari.ImagePhoto;
                        _appdbcontext.SaveChanges();
                        return RedirectToAction("HomeListOfProducts", "ProductManagement");

                        
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message); 
                   
                }

                //bool x = _productRepository.UpdateProduct(id,vari);

                //if (x) //true
                //{
                //    return RedirectToAction("HomeListOfProducts", "ProductManagement");
                //}
                //else //erro
                //{
                //    return RedirectToAction("HomeListOfProducts", "ProductManagement");
                //}

            }
            else
            {
                return RedirectToAction("HomeListOfProducts", "ProductManagement");
            }
        }

    }
}
