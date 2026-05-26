using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;

namespace Supply_Manager.BLL.Services
{
    public class ProveedorService
    {
        private readonly IUnitOfWork _uow;

        public ProveedorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _uow.ProveedorRepository.ObtenerTodos();
        }

        public List<Proveedor> ObtenerFiltrado(string nombre)
        {
            return _uow.ProveedorRepository.ObtenerFiltrado(nombre);
        }

        public void Insertar(Proveedor proveedor)
        {
            Validar(proveedor);
            _uow.ProveedorRepository.Insertar(proveedor);
        }

        public void Actualizar(Proveedor proveedor)
        {
            if (proveedor.IdProveedor <= 0)
                throw new ArgumentException("Seleccione un proveedor de la lista para actualizar.");
            Validar(proveedor);
            _uow.ProveedorRepository.Actualizar(proveedor);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Seleccione un proveedor de la lista para eliminar.");
            _uow.ProveedorRepository.Eliminar(id);
        }

        private void Validar(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.NombreProveedor))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");
            if (proveedor.NombreProveedor.Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
            if (!string.IsNullOrEmpty(proveedor.Telefono) && proveedor.Telefono.Length > 20)
                throw new ArgumentException("El teléfono no puede superar los 20 caracteres.");
            if (!string.IsNullOrEmpty(proveedor.Correo))
            {
                if (!Regex.IsMatch(proveedor.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("El formato del correo electrónico no es válido.");
                if (proveedor.Correo.Length > 100)
                    throw new ArgumentException("El correo no puede superar los 100 caracteres.");
            }
        }
    }
}
