using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitExample.Negocio.Modelo;

namespace UnitExample.Negocio.Repositorio.Interfaz
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<OrderModel> AddOrderAsync(OrderModel newOrder);
    }
}
