using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethinyShop.Repositories;
using Microsoft.AspNetCore.Identity;
using BethinyShop.Repositories.Interfaces;
using BethinyShop.Models;
using BethinyShop.ViewModel.Category;
using BethinyShop.Models.Category;

namespace BethinyShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly AppDbContext _db;

        public CategoryController(ICategoryRepository categoryRepository, UserManager<IdentityUser> um, AppDbContext apdb)
        {
            _categoryRepository = categoryRepository;

            _userManager = um;

            _db = apdb;
        }
        public IActionResult DisplayCategories()
        {
            var ccategories = _categoryRepository.GetAllCategories().OrderBy(p => p.Name);

            var obj = new CategoryViewModel()
            {
                cvmcategories = ccategories.ToList()
            };

            return View(obj);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel vari)
        {
                CategoryModel p = new CategoryModel
                {
                    Name = vari.Name,
                    IsActive = vari.IsActive

                };
                
                int x = _categoryRepository.AddCategory(p);

                if (x > 0) //success
                {
                    return RedirectToAction("DisplayCategories", "Category");
                }
                else //failure
                {
                    return RedirectToAction("AddCategory", "Category");
                }

        }

        [HttpPost]
        public IActionResult DeleteCategory(int ID)
        {
            bool result = _categoryRepository.DeleteCategory(ID);

            if (result)
            {
                return RedirectToAction("DisplayCategories", "Category");
            }
            else
            {
                return RedirectToAction("DisplayCategories", "Category");
            }

        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);

            if (category == null) return RedirectToAction("DisplayCategories", "Category");

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(int id, CategoryModel vari)
        {
            if (ModelState.IsValid)
            {
                CategoryModel categ = _db.CategoryModels.Where(x => x.Id == id).FirstOrDefault();

                if (categ == null) return NotFound();

                try
                {
                    categ.Name = vari.Name;
                    categ.IsActive = vari.IsActive;

                    _db.SaveChanges();

                    return RedirectToAction("DisplayCategories", "Category");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }

            }
            else
            {
                return RedirectToAction("DisplayCategories", "Category");
            }
        }
    }
}
