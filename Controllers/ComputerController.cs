using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Controllers
{
    public class ComputerController : Controller
    {
        public IActionResult ComputerMenuPage()
        {
            return View();
        }
    }
}
