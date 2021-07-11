using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethinyShop.Models.Category;

namespace BethinyShop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetAllCategories();

        CategoryModel GetCategoryById(int prodId);

        int AddCategory(CategoryModel vari);

        bool UpdateCategory(int id, CategoryModel vari);

        bool DeleteCategory(int ID);
    }
}
