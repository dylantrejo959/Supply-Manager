using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Supply_Manager.Utils
{
    public class DbConnectionSingleton
    {
        private static SqlConnection _instancia;

        private DbConnectionSingleton()
        {

        }

        public static SqlConnection Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    string cadenaConexion = ConfigurationManager
                        .ConnectionStrings["ConexionBD"]
                        .ConnectionString;

                    _instancia = new SqlConnection(cadenaConexion);
                }

                return _instancia;
            }
        }
    }
}