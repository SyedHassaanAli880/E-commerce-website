using BethinyShop.Auth;
using BethinyShop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BethinyShop.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        private RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _roleManager = roleManager;
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;

            return View(users);
        }

        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new ApplicationUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
                Birthdate = addUserViewModel.Birthdate,
                City = addUserViewModel.City,
                Country = addUserViewModel.Country
            };

            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(addUserViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) return RedirectToAction("UserManagement", _userManager.Users);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string UserName, string Email)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.Email = Email;

                user.UserName = UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) RedirectToAction("UserManagement", _userManager.Users);
                else ModelState.AddModelError("", "User not updated. Something went wrong.");
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
            }
            return RedirectToAction("UserManagement", _userManager.Users);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);

                if (result.Succeeded) RedirectToAction("UserManagement");
                else
                    ModelState.AddModelError("", "User not deleted. Something went wrong.");
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
            }
            return View("UserManagement", _userManager.Users);
        }

        //public IActionResult AddNewRole() => View();

        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddRoleViewModel arvm)
        {
            if (!ModelState.IsValid)
            {
                return View(arvm);
            }

            var role = new IdentityRole
            {
                Name = arvm.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(arvm);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role == null)
            {
                RedirectToAction("RoleManagement",_roleManager.Roles);
            }

            var editRoleViewModel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };

            foreach(var user in _userManager.Users)
            {
                if( await _userManager.IsInRoleAsync(user,role.Name))
                {
                    editRoleViewModel.Users.Add(user.UserName);
                }
            }

            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel edrm)
        {
            var role = await _roleManager.FindByIdAsync(edrm.Id);

            if (role != null)
            {
                role.Name = edrm.RoleName;
                
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded) return RedirectToAction("RoleManagement", _roleManager.Roles);

                ModelState.AddModelError("","Role not updated, something went wrong.");

                return View(edrm);
            }

            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded) RedirectToAction("RoleManagement",_roleManager.Roles);
                else
                    ModelState.AddModelError("", "Role not deleted. Something went wrong.");
            }
            else
            {
                ModelState.AddModelError("", "Role not found.");
            }
            return View("RoleManagement", _roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                RedirectToAction("RoleManagement", _roleManager.Roles);
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded) RedirectToAction("RoleManagement", _roleManager.Roles);
                else
                    ModelState.AddModelError("", "Role not deleted. Something went wrong.");
            }

            var addusertoROLEviewmodel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addusertoROLEviewmodel.Users.Add(user);
                }
            }

            return View(addusertoROLEviewmodel); 
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel vari)
        {
            var user = await _userManager.FindByIdAsync(vari.UserId);

            var role = await _roleManager.FindByIdAsync(vari.RoleId);

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
               
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

            return View(vari);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole(string roleID)
        {
            var role = await _roleManager.FindByIdAsync(roleID);

            if (role == null)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            }

            var addusertoROLEviewmodel = new UserRoleViewModel { RoleId = role.Id };

            
            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addusertoROLEviewmodel.Users.Add(user);
                }
            }

            return View(addusertoROLEviewmodel);
        }

    }
}
