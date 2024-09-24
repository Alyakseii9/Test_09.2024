using Microsoft.EntityFrameworkCore;
using My_1_w.Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_1_w.infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly CatalogContext _dbContext;

        public EfRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public T? GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
