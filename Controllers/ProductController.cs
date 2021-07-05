using BethinyShop.Models;
using BethinyShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BethinyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly AppDbContext _db;

        public ProductController(IProductRepository productRepository, UserManager<IdentityUser> um, AppDbContext apdb)
        {
            _productRepository = productRepository;

            _userManager = um;

            _db = apdb;
        }

        public IActionResult Index()
        {
            var pproducts = _productRepository.GetAllProducts().OrderBy(p => p.Name);

            var obj = new ProductViewModel()
            {
                Title = "Products Shop",

                Products = pproducts.ToList()
            };

            return View(obj);
        }

        public IActionResult Details(int ID)
        {
            var product = _productRepository.GetProductById(ID);

           if(product == null)
           {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult SearchProducts(string searchProduct)
        {
            if(string.IsNullOrEmpty(searchProduct))
            {
                //var product = _productRepository.GetProductById(ID);
                return View();
            }
            return View();
        }

        
    }
}
