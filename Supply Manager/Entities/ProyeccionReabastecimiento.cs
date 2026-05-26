namespace Supply_Manager.Entities
{
    public class ProyeccionReabastecimiento
    {
        public string NombreInsumo { get; set; }
        public string UnidadMedida { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int ConsumoUltimos30Dias { get; set; }
        public decimal ConsumoPromedioDiario { get; set; }
        public int DiasHastaNivelMinimo { get; set; }
        public int CantidadSugeridaReorden { get; set; }
    }
}
