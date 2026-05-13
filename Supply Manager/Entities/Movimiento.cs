using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Manager.Entities
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }

        public string TipoMovimiento { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public int Cantidad { get; set; }

        public string Observacion { get; set; }

        public int IdInsumo { get; set; }

        public int IdArea { get; set; }

        public int IdUsuario { get; set; }
    }
}