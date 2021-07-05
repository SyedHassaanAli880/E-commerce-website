using System.Collections.Generic;
using BethinyShop.Models;
using BethinyShop.Models.ToSee;

namespace BethinyShop.ViewModel
{
    public class ProductViewModel
    {

        public string Title { get; set; }

        public List<BethinyShop.Models.Product> Products { get; set; }
    }
}
