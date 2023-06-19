using Ecommerce.Repositorio.DBContext;
using Ecommerce.Repositorio.Interfaces;
using System.Linq.Expressions;

namespace Ecommerce.Repositorio.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcommerceDbContext _dbContext;

        public GenericRepository( EcommerceDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create( T model )
        {
            try
            {
                _dbContext.Set<T>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch ( Exception e )
            {
                throw;
            }
        }

        public async Task<bool> Delete( T model )
        {
            try
            {
                _dbContext.Set<T>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch ( Exception e )
            {
                throw;
            }
        }

        public async Task<bool> Edit( T model )
        {
            try
            {
                _dbContext.Set<T>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch ( Exception e )
            {
                throw;
            }
        }

        public IQueryable<T> Get( Expression<Func<T, bool>>? filter = null )
        {
            IQueryable<T> get = (filter == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filter);

            return get;
        }
    }
}
