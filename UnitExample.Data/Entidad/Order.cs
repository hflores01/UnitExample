using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnitExample.Data.Entidad
{
    public partial class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = null!;

    }
}
