using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BethinyShop.ViewModel;

namespace BethinyShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager; _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginviewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginviewModel);
            }

            var user = await
                _userManager.FindByNameAsync(loginviewModel.UserName);

            if (user != null)
            {
                var result = await
                    _signInManager.PasswordSignInAsync(user, loginviewModel.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Pie");
                }
            }

            ModelState.AddModelError("", "Username/password not found!");

            return View(loginviewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginviewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                { UserName = loginviewModel.UserName };

                var result = await _userManager.CreateAsync(user, loginviewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Pie");
                }

            }

            return View(loginviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Pie");
        }

        
    }  
}
