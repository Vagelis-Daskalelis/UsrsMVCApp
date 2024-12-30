
using Microsoft.EntityFrameworkCore;
using UsrsMVCApp.Models;

namespace UsrsMVCApp.Repositories
{
    public abstract class BaseReposiroty<T> : IBaseReporitory<T> 
        where T : class
    {

        public readonly Stdnts5DbContext _context;
        private readonly DbSet<T>? _dbSet;

        protected BaseReposiroty(Stdnts5DbContext context)
        {
            _context = context;
            _dbSet = _context!.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet!.AddAsync(entity); 
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet!.AddRangeAsync(entities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T? existing = await _dbSet!.FindAsync(id);
            if (existing is not null) 
            { 
                _dbSet.Remove(existing);

                return true;
            }
            return false;
        }

        public virtual async Task<IEnumerable<T>> getAllAsync()
        {
            var entities = await _dbSet!.ToListAsync();
            return entities;
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            var entity = await _dbSet!.FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync()
        {
           var count = await _dbSet!.CountAsync();
            return count;
        }

        public virtual void UpdateAsync(T entity)
        {
            _dbSet!.Attach(entity);
            _context!.Entry(entity).State = EntityState.Modified;
        }
    }
}
