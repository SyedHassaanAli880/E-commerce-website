using BethinyShop.Models;
using BethinyShop.Repositories.Interfaces;
using BethinyShop.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackrepository;

        
        public FeedbackController(IFeedbackRepository feedbackrepository)
        {
            _feedbackrepository = feedbackrepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                _feedbackrepository.AddFeedback(feedback);

                return RedirectToAction("FeedbackComplete");
            }
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
