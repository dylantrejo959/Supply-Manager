using System.Collections.Generic;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IInsumoRepository
    {
        List<Insumo> ObtenerTodos();
        List<Insumo> ObtenerFiltrado(string nombre, string unidadMedida, bool soloStockCritico);
        void Insertar(Insumo insumo);
        void Actualizar(Insumo insumo);
        void Desactivar(int id);
    }
}
