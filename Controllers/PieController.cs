using BethinyShop.ViewModel;
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

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var ppies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var obj = new PieViewModel()
            {
                Title = "PIE SHOP",

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

    }
}
