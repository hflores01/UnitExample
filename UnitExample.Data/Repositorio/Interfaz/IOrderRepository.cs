using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitExample.Data.Entidad;

namespace UnitExample.Data.Repositorio.Interfaz
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderByIdAsync(int id);

        Task<List<Order>> GetAllOrdersAsync();

        Task<List<OrderAgregado>> GetV_OrdenesAsync(ReporteAgregado parametros);
    }
}
