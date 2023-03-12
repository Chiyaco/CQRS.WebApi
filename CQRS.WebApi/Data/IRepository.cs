using System.Linq.Expressions;

namespace CQRS.WebApi.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        int GetNextSequenceValue(string name);

        Task<IEnumerable<T>> GetAll();

        IEnumerable<T> QuerySql(string rawSql);

        IQueryable<T> GetAllPaged();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> GetAllAsNoTracking(Expression<Func<T, bool>> where);

        IQueryable<T> GetAllPaged(Expression<Func<T, bool>> where);

        Task<T> Get(Guid id);

        Task Insert(T entity);

        Task BulkInsert(IEnumerable<T> entity);

        Task<int> Update(T entity);

        Task Delete(T entity);

        Task Commit();
    }
}
