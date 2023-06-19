using Ecommerce.Model;

namespace Ecommerce.Repositorio.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Register(Venta venta);
        
    }
}
