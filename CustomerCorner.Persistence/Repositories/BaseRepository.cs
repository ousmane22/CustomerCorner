using CustomerCorner.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly CustomerCornerDbContext _customerCornerDbContext;

        public BaseRepository(CustomerCornerDbContext customerCornerDbContext)
        {
            _customerCornerDbContext = customerCornerDbContext;
        }


        public async Task<T> AddAsync(T entity)
        {
          await  _customerCornerDbContext.Set<T>().AddAsync(entity);
          await _customerCornerDbContext.SaveChangesAsync();

          return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _customerCornerDbContext.Set<T>().Remove(entity);
            await _customerCornerDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _customerCornerDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
           return await _customerCornerDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _customerCornerDbContext.Entry(entity).State = EntityState.Modified;
            await _customerCornerDbContext.SaveChangesAsync();
        }
    }
}
