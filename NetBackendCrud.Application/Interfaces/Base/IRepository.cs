using System.Linq.Expressions;

namespace NetBackendCrud.Application.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filtro = null);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>>? filtro = null, bool tracked = true);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
        Task SaveChangesAsync();
    }
}
