using System;
using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IMovimientoRepository
    {
        void Registrar(Movimiento movimiento);
        List<MovimientoDetalle> ObtenerFiltrado(int? idInsumo, int? idArea, string tipoMovimiento, DateTime? fechaDesde, DateTime? fechaHasta);
    }
}
