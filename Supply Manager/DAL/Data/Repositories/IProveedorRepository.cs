using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IProveedorRepository
    {
        List<Proveedor> ObtenerTodos();
        List<Proveedor> ObtenerFiltrado(string nombre);
        void Insertar(Proveedor proveedor);
        void Actualizar(Proveedor proveedor);
        void Eliminar(int id);
    }
}
