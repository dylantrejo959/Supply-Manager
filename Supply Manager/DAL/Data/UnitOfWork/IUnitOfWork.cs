using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.DAL.Data.Repositories;

namespace Supply_Manager.DAL.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInsumoRepository InsumoRepository { get; }
    }
}