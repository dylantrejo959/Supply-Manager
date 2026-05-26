using System;

namespace Supply_Manager.Entities
{
    public class MovimientoDetalle
    {
        public int IdMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public string NombreInsumo { get; set; }
        public string NombreArea { get; set; }
        public string NombreUsuario { get; set; }
    }
}
