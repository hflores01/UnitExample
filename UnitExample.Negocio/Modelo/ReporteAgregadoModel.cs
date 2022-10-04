using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitExample.Negocio.Modelo
{
    public class ReporteAgregadoModel
    {
        public string? fileType{ get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime fechaRegistroInicial { get; set; }
        public DateTime fechaRegistroFinal { get; set; }

    }
}
