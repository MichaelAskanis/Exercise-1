using SynetecMvcAssesment.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssesment.DataAccess.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public GenericRepository(DbContext context)
        {
            _entities = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }
    }
}
