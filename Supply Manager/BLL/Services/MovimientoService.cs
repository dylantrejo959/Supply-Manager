using System;
using System.Collections.Generic;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;

namespace Supply_Manager.BLL.Services
{
    public class MovimientoService
    {
        private readonly IUnitOfWork _uow;

        public MovimientoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // Regla de negocio: movimientos son inmutables (solo registro, no edición ni eliminación)
        public void Registrar(Movimiento movimiento)
        {
            ValidarMovimiento(movimiento);
            _uow.MovimientoRepository.Registrar(movimiento);
        }

        public List<MovimientoDetalle> ObtenerFiltrado(int? idInsumo, int? idArea, string tipoMovimiento, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde.Value > fechaHasta.Value)
                throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha fin.");
            return _uow.MovimientoRepository.ObtenerFiltrado(idInsumo, idArea, tipoMovimiento, fechaDesde, fechaHasta);
        }

        private void ValidarMovimiento(Movimiento movimiento)
        {
            if (movimiento.IdInsumo <= 0)
                throw new ArgumentException("Debe seleccionar un insumo.");
            if (movimiento.IdArea <= 0)
                throw new ArgumentException("Debe seleccionar un área.");
            if (string.IsNullOrWhiteSpace(movimiento.TipoMovimiento) ||
                (movimiento.TipoMovimiento != "Entrada" && movimiento.TipoMovimiento != "Salida"))
                throw new ArgumentException("El tipo de movimiento debe ser Entrada o Salida.");
            if (movimiento.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (movimiento.FechaMovimiento > DateTime.Now)
                throw new ArgumentException("La fecha del movimiento no puede ser futura.");
        }
    }
}
