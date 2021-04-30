using BethinyShop.Models;
using BethinyShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly AppDbContext _db;

        public PieController(IPieRepository pieRepository, UserManager<IdentityUser> um, AppDbContext apdb)
        {
            _pieRepository = pieRepository;

            _userManager = um;

            _db = apdb;
        }

        public IActionResult Index()
        {
            var ppies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var obj = new PieViewModel()
            {
                Title = "Pie Shop",

                Pies = ppies.ToList()
            };

            return View(obj);
        }

        public IActionResult Details(int ID)
        {
            var pie = _pieRepository.GetPieById(ID);

           if(pie == null)
           {
                return NotFound();
            }
            return View(pie);
        }

        public IActionResult SearchPies(string searchPie)
        {
            if(string.IsNullOrEmpty(searchPie))
            {
                //var pie = _pieRepository.GetPieById(ID);
                return View();
            }
            return View();
        }

        
    }
}
