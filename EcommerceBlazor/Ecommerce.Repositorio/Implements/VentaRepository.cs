using Ecommerce.Model;
using Ecommerce.Repositorio.DBContext;
using Ecommerce.Repositorio.Interfaces;

namespace Ecommerce.Repositorio.Implements
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public VentaRepository( EcommerceDbContext dbContext ) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Register( Venta venta )
        {
            Venta ventaGenerada = new Venta();

            using ( var transaction = _dbContext.Database.BeginTransaction() )
            {
                try
                {
                    foreach ( DetalleVenta detalleVenta in venta.DetalleVenta )
                    {
                        Producto productoEncontrado = _dbContext.Productos.Where(p => p.IdProducto == detalleVenta.IdProducto).First();

                        productoEncontrado.Cantidad -= detalleVenta.Cantidad;
                        _dbContext.Productos.Update( productoEncontrado );
                    }

                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(venta);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = venta;

                    transaction.Commit();
                }
                catch ( Exception e )
                {

                    transaction.Rollback();
                    throw;
                }
            }
                return ventaGenerada;
        }
    }
}
