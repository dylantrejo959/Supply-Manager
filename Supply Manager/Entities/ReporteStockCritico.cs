namespace Supply_Manager.Entities
{
    public class ReporteStockCritico
    {
        public string NombreInsumo { get; set; }
        public string UnidadMedida { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int Deficit { get; set; }
    }
}
