using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.DAL.Data.UnitOfWork;

namespace Supply_Manager.Factory
{
    public interface IRepositoryFactory
    {
        IUnitOfWork CrearUnidadDeTrabajo();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IUnitOfWork CrearUnidadDeTrabajo()
        {
            return new UnitOfWork();
        }
    }
}
