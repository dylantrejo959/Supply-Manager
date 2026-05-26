using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Manager.Entities
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public string Descripcion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string UnidadMedida { get; set; }
        public bool Estado { get; set; } = true;
    }
}
