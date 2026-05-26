using Supply_Manager.DAL.Data.Repositories;

namespace Supply_Manager.DAL.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInsumoRepository InsumoRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        IMovimientoRepository MovimientoRepository { get; }
        IAreaRepository AreaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IReporteRepository ReporteRepository { get; }
    }
}
