using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        
        private List<Pie> _pies;
        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie { Id = 1, Name = "Apple Pie", Price = 12.59M, ShortDescription = "Short desc 1", LongDescription = "Long desc 1",ImageUrl="Apple pie.jpeg", IsPieOfTheWeek=true},
                new Pie { Id = 2, Name = "Blue berry", Price = 18.59M, ShortDescription = "Short desc 2", LongDescription = "Long desc 2", ImageUrl="blue berry pie.jpg", IsPieOfTheWeek=true},
                new Pie { Id = 3, Name = "Cheese Cake", Price = 17.59M, ShortDescription = "Short desc 3", LongDescription = "Long desc 3",ImageUrl="cheese pie.jpg", IsPieOfTheWeek=true},
                new Pie { Id = 4, Name = "Cherry Pie", Price = 15.59M, ShortDescription = "Short desc 4", LongDescription = "Long desc 4", ImageUrl="cherry pie.jpg", IsPieOfTheWeek=true}

            };
        }

        public MockPieRepository()
        {
            if(_pies == null)
            {
                InitializePies();
            }
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
