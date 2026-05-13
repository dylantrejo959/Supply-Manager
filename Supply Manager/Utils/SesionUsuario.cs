using Supply_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return UsuarioActual != null
                && UsuarioActual.Rol == "Administrador";
        }
    }
}
