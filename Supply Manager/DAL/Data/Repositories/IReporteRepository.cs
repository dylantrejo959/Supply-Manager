using System;
using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IReporteRepository
    {
        List<ReporteStockCritico> ObtenerStockCritico();
        List<ReporteConsumo> ObtenerConsumo(DateTime fechaDesde, DateTime fechaHasta, int? idArea);
        List<ProyeccionReabastecimiento> ObtenerProyeccion();
    }
}
