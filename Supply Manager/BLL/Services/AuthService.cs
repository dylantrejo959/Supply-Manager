using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.Entities;
using Supply_Manager.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Supply_Manager.BLL.Services
{
    internal class AuthService
    {
        public Usuario Login(string usuario, string clave)
        {
            SqlConnection conexion = DbConnectionSingleton.Instancia;

            SqlCommand comando =
                new SqlCommand("sp_Login", conexion);

            comando.CommandType =
                CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Usuario", usuario);

            comando.Parameters.AddWithValue("@Clave", clave);

            try
            {
                conexion.Open();

                SqlDataReader reader =
                    comando.ExecuteReader();

                if (reader.Read())
                {
                    Usuario user = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        NombreUsuario = reader["Usuario"].ToString(),
                        Rol = reader["NombreRol"].ToString()
                    };

                    reader.Close();

                    return user;
                }

                reader.Close();

                return null;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
