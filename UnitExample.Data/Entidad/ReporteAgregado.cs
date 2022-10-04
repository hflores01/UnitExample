using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitExample.Data.Entidad
{
    public class ReporteAgregado
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime fechaRegistroInicial { get; set; }
        public DateTime fechaRegistroFinal { get; set; }
    }
}
