using System;
using System.Collections.Generic;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;

namespace Supply_Manager.BLL.Services
{
    public class AreaService
    {
        private readonly IUnitOfWork _uow;

        public AreaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Area> ObtenerTodas()
        {
            return _uow.AreaRepository.ObtenerTodas();
        }

        public void Insertar(Area area)
        {
            Validar(area);
            _uow.AreaRepository.Insertar(area);
        }

        public void Actualizar(Area area)
        {
            if (area.IdArea <= 0)
                throw new ArgumentException("Seleccione un área de la lista para actualizar.");
            Validar(area);
            _uow.AreaRepository.Actualizar(area);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Seleccione un área de la lista para eliminar.");
            _uow.AreaRepository.Eliminar(id);
        }

        private void Validar(Area area)
        {
            if (string.IsNullOrWhiteSpace(area.NombreArea))
                throw new ArgumentException("El nombre del área es obligatorio.");
            if (area.NombreArea.Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
        }
    }
}
