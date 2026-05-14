using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.Entities;

namespace Supply_Manager.DAL.Data.Repositories
{
    public interface IInsumoRepository
    {
        List<Insumo> ObtenerTodos();

        void Insertar(Insumo insumo);

        void Actualizar(Insumo insumo);

        void Eliminar(int id);
    }
}
