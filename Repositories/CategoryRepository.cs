using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethinyShop.Repositories.Interfaces;
using BethinyShop.Models.Category;
using BethinyShop.Models;

namespace BethinyShop.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _appDbContext.CategoryModels;
        }

        public CategoryModel GetCategoryById(int prodId)
        {
            return _appDbContext.CategoryModels.FirstOrDefault(p => p.Id == prodId);
        }

        public int AddCategory(CategoryModel vari)
        {
            _appDbContext.CategoryModels.Add(vari);

            int x = _appDbContext.SaveChanges();

            return x;
        }

        public bool UpdateCategory(int id, CategoryModel vari)
        {
            var prod = _appDbContext.Products.FirstOrDefault(x => x.Id == id);

            if (prod != null)
            {
                CategoryModel cm = new CategoryModel
                {
                    Name = vari.Name,
                    IsActive = vari.IsActive
                };

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool DeleteCategory(int ID)
        {
            var cat = _appDbContext.CategoryModels.FirstOrDefault(x => x.Id == ID);

            if (cat != null)
            {
                _appDbContext.Remove(cat);

                _appDbContext.SaveChanges();

                return true;
            }


            return false;
        }
    }
}
