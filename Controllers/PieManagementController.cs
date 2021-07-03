using BethinyShop.Models;
using BethinyShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace BethinyShop.Controllers
{
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly AppDbContext _db;

        public PieManagementController(IPieRepository pieRepository, UserManager<IdentityUser> um, AppDbContext apdb)
        {
            _pieRepository = pieRepository;

            _userManager = um;

            _db = apdb;
        }

        public IActionResult HomeListOfPies()
        {
            var ppies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var obj = new PieViewModel()
            {
                Title = "Pie Shop",

                Pies = ppies.ToList()
            };

            return View(obj);
        }
    }
}
