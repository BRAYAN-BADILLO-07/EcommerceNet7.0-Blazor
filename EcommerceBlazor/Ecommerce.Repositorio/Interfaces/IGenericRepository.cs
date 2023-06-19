using System.Linq.Expressions;

namespace Ecommerce.Repositorio.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>>? filter = null);
        Task<T> Create( T model );
        Task<bool> Edit( T model );
        Task<bool> Delete( T model );
    }
}
