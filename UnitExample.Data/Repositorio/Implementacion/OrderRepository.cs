using Microsoft.EntityFrameworkCore;
using UnitExample.Data.Entidad;
using UnitExample.Data.Repositorio.Interfaz;

namespace UnitExample.Data.Repositorio.Implementacion
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected readonly RepositoryPatternContext _repositoryPatternContext;
        public OrderRepository(RepositoryPatternContext repositoryPatternContext) : base(repositoryPatternContext)
        {
            _repositoryPatternContext = repositoryPatternContext;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            Order? orden = new Order();
            using (var db = _repositoryPatternContext)
            {
                orden = await db.Order.Where(x => x.Id == id)
                    .Include(u => u.Customer)
                    .Include(v => v.OrderDetails)
                    .ThenInclude(w => w.Product)
                    .SingleOrDefaultAsync();
            }

            return orden;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await GetAll().ToListAsync();
        }

    }
}
