using Supply_Manager.DAL.Data.Repositories;

namespace Supply_Manager.DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInsumoRepository InsumoRepository { get; }
        public IProveedorRepository ProveedorRepository { get; }
        public IMovimientoRepository MovimientoRepository { get; }
        public IAreaRepository AreaRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IReporteRepository ReporteRepository { get; }

        public UnitOfWork()
        {
            InsumoRepository = new InsumoRepository();
            ProveedorRepository = new ProveedorRepository();
            MovimientoRepository = new MovimientoRepository();
            AreaRepository = new AreaRepository();
            UsuarioRepository = new UsuarioRepository();
            ReporteRepository = new ReporteRepository();
        }
    }
}
