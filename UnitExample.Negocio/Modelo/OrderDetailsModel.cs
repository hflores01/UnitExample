using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitExample.Negocio.Modelo
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual OrderModel Order { get; set; } = null!;
        public virtual ProductModel Product { get; set; } = null!;

    }
}
