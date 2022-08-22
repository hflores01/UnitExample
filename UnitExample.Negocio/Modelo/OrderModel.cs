using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitExample.Negocio.Modelo
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Fecha { get; set; }
        public virtual CustomerModel Customer { get; set; } = null!;
        public virtual List<OrderDetailsModel> OrderDetails { get; set; } = null!;

    }
}
