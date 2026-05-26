using System;
using System.Collections.Generic;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;

namespace Supply_Manager.BLL.Services
{
    public class ReporteService
    {
        private readonly IUnitOfWork _uow;

        public ReporteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<ReporteStockCritico> ObtenerStockCritico()
        {
            return _uow.ReporteRepository.ObtenerStockCritico();
        }

        public List<ReporteConsumo> ObtenerConsumo(DateTime fechaDesde, DateTime fechaHasta, int? idArea)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha fin.");
            return _uow.ReporteRepository.ObtenerConsumo(fechaDesde, fechaHasta, idArea);
        }

        public List<ProyeccionReabastecimiento> ObtenerProyeccion()
        {
            return _uow.ReporteRepository.ObtenerProyeccion();
        }
    }
}
