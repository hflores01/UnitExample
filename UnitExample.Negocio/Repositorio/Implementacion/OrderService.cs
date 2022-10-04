using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitExample.Data.Entidad;
using UnitExample.Data.Repositorio;
using UnitExample.Data.Repositorio.Interfaz;
using UnitExample.Negocio.Modelo;
using UnitExample.Negocio.Repositorio.Interfaz;

namespace UnitExample.Negocio.Repositorio.Implementacion
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            Order? item = await _orderRepository.GetOrderByIdAsync(id);
            OrderModel model = new OrderModel();
            if (item != null)
            {
                model.Id = item.Id;
                model.CustomerId = item.CustomerId;
                model.Fecha = item.Fecha;
                model.Customer = new CustomerModel()
                {
                    FirstName = item.Customer == null ? string.Empty : item.Customer.FirstName,
                    LastName = item.Customer == null ? string.Empty : item.Customer.LastName,
                    Age = item.Customer == null ? 0 : item.Customer.Age,

                };
                List<OrderDetailsModel> details = new List<OrderDetailsModel>();

                foreach (OrderDetails line in item.OrderDetails)
                {
                    OrderDetailsModel lineModel = new OrderDetailsModel()
                    {
                        Id = line.Id,
                        OrderId = line.OrderId,
                        ProductId = line.ProductId,
                        Product = new ProductModel()
                        {
                            Description = line.Product.Description,
                            Id = line.Product.Id,
                            Name = line.Product.Name,
                            Price = line.Product.Price,
                        },
                    };
                    details.Add(lineModel);

                }
                model.OrderDetails = details;

            }
            return model;
        }

        public async Task<OrderModel> AddOrderAsync(OrderModel newOrder)
        {
            Order order = new Order();
            order.CustomerId = newOrder.CustomerId;
            order.Fecha = newOrder.Fecha;

            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (OrderDetailsModel item in newOrder.OrderDetails)
            {
                OrderDetails line = new OrderDetails();
                line.ProductId = item.ProductId;
                orderDetails.Add(line);
            }
            order.OrderDetails = orderDetails;

            order = await _orderRepository.AddAsync(order);
            newOrder.Id = order.Id;
            return newOrder;
        }

        public async Task<List<OrderAgregadoModel>> GetV_OrdenesAsync(ReporteAgregadoModel parametros)
        {
            List<OrderAgregadoModel> tramitesModel = new List<OrderAgregadoModel>();
            try
            {
                ReporteAgregado param = new ReporteAgregado();
                param.fechaRegistroInicial = parametros.fechaRegistroInicial;
                param.fechaRegistroFinal = parametros.fechaRegistroFinal;

                foreach (OrderAgregado item in await _orderRepository.GetV_OrdenesAsync(param))
                {
                    OrderAgregadoModel model = new OrderAgregadoModel();
                    model.Id = item.Id;
                    model.LastName = item.LastName.Trim();
                    model.Name = item.Name.Trim();
                    model.FirstName = item.FirstName.Trim();
                    model.CustomerId = item.CustomerId;
                    model.ProductId = item.ProductId;
                    model.Description = item.Description.Trim();
                    model.Fecha = item.Fecha;
                    model.Price = item.Price;

                    tramitesModel.Add(model);
                }
            }
            catch (Exception ex)
            {
                //ErrorEntity err = new ErrorEntity();
                //err.Excepcion = ex;
                //err.Rutina = "GetV_OrdenesAsync";
                //err.TipoCapturado = "UnitExample.Negocio";
                //ErrorEntity.EscribirError(err);
                throw;
            }
            return tramitesModel;
        }
    }

}
