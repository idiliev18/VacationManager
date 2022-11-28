using api.Contracts;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly VacationManagerDbContext _context;

        public Repository(VacationManagerDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity is not null;
        }

        public async virtual Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            var res = await _context.Set<T>().FindAsync(id);
            

            return res;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
