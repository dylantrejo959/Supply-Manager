using Supply_Manager.Entities;

namespace Supply_Manager.Utils
{
    public static class SesionUsuario
    {
        public static Usuario UsuarioActual { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public static bool EsAdministrador()
        {
            return UsuarioActual?.Rol == "Administrador";
        }

        public static bool EsAlmacenista()
        {
            return UsuarioActual?.Rol == "Almacenista";
        }

        public static bool EsSupervisor()
        {
            return UsuarioActual?.Rol == "Supervisor";
        }

        // Puede registrar movimientos y hacer CRUD de insumos/proveedores/áreas
        public static bool PuedeModificar()
        {
            return EsAdministrador() || EsAlmacenista();
        }
    }
}
