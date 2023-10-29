using System.Linq.Expressions;

namespace CollegeFootballApp.Application.Infrastructure
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(int id);

        Task<T> Get(string id);

        Task<T> Get(Guid id);
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<T> FindSingle(Expression<Func<T, bool>> predicate);
        Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Delete(T entity);
        void BulkInsert(IEnumerable<T> entities);
        Task SaveChanges();
    }
}
