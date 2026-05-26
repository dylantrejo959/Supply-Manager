using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IAreaRepository
    {
        List<Area> ObtenerTodas();
        void Insertar(Area area);
        void Actualizar(Area area);
        void Eliminar(int id);
    }
}
