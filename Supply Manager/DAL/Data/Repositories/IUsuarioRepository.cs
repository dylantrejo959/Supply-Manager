using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> ObtenerTodos();
        List<Rol> ObtenerRoles();
        void Insertar(string nombreUsuario, string clave, int idRol);
        void Actualizar(int idUsuario, string nombreUsuario, int idRol);
        void Desactivar(int idUsuario);
    }
}
