using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitExample.Negocio.Modelo
{
    public class OrderAgregadoModel
    {
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public int CustomerId { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;

	}
}
