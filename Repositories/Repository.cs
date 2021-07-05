using BethinyShop.Models;
using BethinyShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.Repositories
{
    public class Repository<T> : Interface<T> where T : class
    {
        private readonly AppDbContext _context;

        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;

            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int ID)
        {
            return _entities.Find(ID);
        }

    }
}
