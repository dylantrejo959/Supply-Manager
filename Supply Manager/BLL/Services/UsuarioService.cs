using System;
using System.Collections.Generic;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.BLL.Services
{
    public class UsuarioService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Usuario> ObtenerTodos()
        {
            VerificarAdministrador();
            return _uow.UsuarioRepository.ObtenerTodos();
        }

        public List<Rol> ObtenerRoles()
        {
            return _uow.UsuarioRepository.ObtenerRoles();
        }

        public void Insertar(string nombreUsuario, string clave, int idRol)
        {
            VerificarAdministrador();
            ValidarCredenciales(nombreUsuario, clave);
            if (idRol <= 0) throw new ArgumentException("Debe seleccionar un rol.");
            _uow.UsuarioRepository.Insertar(nombreUsuario, clave, idRol);
        }

        public void Actualizar(int idUsuario, string nombreUsuario, int idRol)
        {
            VerificarAdministrador();
            if (idUsuario <= 0) throw new ArgumentException("Seleccione un usuario de la lista.");
            if (string.IsNullOrWhiteSpace(nombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (nombreUsuario.Length > 50) throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
            if (idRol <= 0) throw new ArgumentException("Debe seleccionar un rol.");
            _uow.UsuarioRepository.Actualizar(idUsuario, nombreUsuario, idRol);
        }

        public void Desactivar(int idUsuario)
        {
            VerificarAdministrador();
            if (idUsuario <= 0) throw new ArgumentException("Seleccione un usuario de la lista.");
            if (SesionUsuario.UsuarioActual != null && SesionUsuario.UsuarioActual.IdUsuario == idUsuario)
                throw new InvalidOperationException("No puede desactivar su propio usuario.");
            _uow.UsuarioRepository.Desactivar(idUsuario);
        }

        private void VerificarAdministrador()
        {
            if (!SesionUsuario.EsAdministrador())
                throw new UnauthorizedAccessException("Solo el Administrador puede gestionar usuarios.");
        }

        private void ValidarCredenciales(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (nombreUsuario.Length > 50)
                throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La contraseña es obligatoria.");
            if (clave.Length < 3)
                throw new ArgumentException("La contraseña debe tener al menos 3 caracteres.");
            if (clave.Length > 100)
                throw new ArgumentException("La contraseña no puede superar los 100 caracteres.");
        }
    }
}
