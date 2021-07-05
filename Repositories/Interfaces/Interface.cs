using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Repositories.Interfaces
{
    public interface Interface<T> where T : class 
    {
        IEnumerable<T> GetAll();

        T GetById(int ID);

    }
}
