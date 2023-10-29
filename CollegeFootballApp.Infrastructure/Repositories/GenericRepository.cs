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
        public virtual async Task<T> Add(T entity)
        {
            var result = await _context.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<T>()
                .AsQueryable()
                .Where(predicate));
        }

        public virtual async Task<T> FindSingle(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> Get(int id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }

        public virtual async Task<T> Get(Guid id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }


        public virtual async Task<T> Get(string id)
        {

            var item = await _context.Set<T>().FindAsync(id);
            return item;

        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> Update(T entity)
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
