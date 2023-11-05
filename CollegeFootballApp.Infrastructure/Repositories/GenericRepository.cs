using CollegeFootballApp.Application.Infrastructure;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public abstract class GenericRepository<T>
      : IRepository<T> where T : class
    {

        protected ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            var result = await _context.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> FindCollectionAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<T>()
                .AsQueryable()
                .Where(predicate));
        }

        public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }


        public virtual async Task<T> GetByIdAsync(string id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Task.Run(() => entity);
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            _context.BulkInsert(entities);
        }
    }
}
