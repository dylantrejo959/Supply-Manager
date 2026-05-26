using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;

namespace Supply_Manager.BLL.Services
{
    public class InsumoService
    {
        private readonly IUnitOfWork _uow;

        public InsumoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Insumo> ObtenerTodos()
        {
            return _uow.InsumoRepository.ObtenerTodos();
        }

        public List<Insumo> ObtenerFiltrado(string nombre, string unidadMedida, bool soloStockCritico)
        {
            return _uow.InsumoRepository.ObtenerFiltrado(nombre, unidadMedida, soloStockCritico);
        }

        public void Insertar(Insumo insumo)
        {
            ValidarInsumo(insumo);
            _uow.InsumoRepository.Insertar(insumo);
        }

        public void Actualizar(Insumo insumo)
        {
            if (insumo.IdInsumo <= 0)
                throw new ArgumentException("Seleccione un insumo de la lista para actualizar.");
            ValidarInsumo(insumo);
            _uow.InsumoRepository.Actualizar(insumo);
        }

        public void Desactivar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Seleccione un insumo de la lista para desactivar.");
            _uow.InsumoRepository.Desactivar(id);
        }

        private void ValidarInsumo(Insumo insumo)
        {
            if (string.IsNullOrWhiteSpace(insumo.NombreInsumo))
                throw new ArgumentException("El nombre del insumo es obligatorio.");
            if (insumo.NombreInsumo.Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
            if (string.IsNullOrWhiteSpace(insumo.UnidadMedida))
                throw new ArgumentException("La unidad de medida es obligatoria.");
            if (insumo.StockActual < 0)
                throw new ArgumentException("El stock actual no puede ser negativo.");
            if (insumo.StockMinimo < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");
        }
    }
}
