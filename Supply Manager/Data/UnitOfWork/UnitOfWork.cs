using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.Data.Repositories;

namespace Supply_Manager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInsumoRepository InsumoRepository { get; }

        public UnitOfWork()
        {
            InsumoRepository = new InsumoRepository();
        }
    }
}