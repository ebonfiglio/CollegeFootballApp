using System.Linq.Expressions;

namespace CollegeFootballApp.Application.Infrastructure
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);

        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindCollectionAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Delete(T entity);
        void BulkInsert(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
