using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection _conexion;

        public UsuarioRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            var cmd = new SqlCommand("sp_ObtenerUsuarios", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        NombreUsuario = reader["Usuario"].ToString(),
                        Rol = reader["NombreRol"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    });
                }
                reader.Close();
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open) _conexion.Close();
            }
            return lista;
        }

        public List<Rol> ObtenerRoles()
        {
            var lista = new List<Rol>();
            var cmd = new SqlCommand("sp_ObtenerRoles", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Rol
                    {
                        IdRol = Convert.ToInt32(reader["IdRol"]),
                        NombreRol = reader["NombreRol"].ToString()
                    });
                }
                reader.Close();
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open) _conexion.Close();
            }
            return lista;
        }

        public void Insertar(string nombreUsuario, string clave, int idRol)
        {
            var cmd = new SqlCommand("sp_InsertarUsuario", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            cmd.Parameters.AddWithValue("@IdRol", idRol);
            EjecutarSinRetorno(cmd);
        }

        public void Actualizar(int idUsuario, string nombreUsuario, int idRol)
        {
            var cmd = new SqlCommand("sp_ActualizarUsuario", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@IdRol", idRol);
            EjecutarSinRetorno(cmd);
        }

        public void Desactivar(int idUsuario)
        {
            var cmd = new SqlCommand("sp_DesactivarUsuario", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            EjecutarSinRetorno(cmd);
        }

        private void EjecutarSinRetorno(SqlCommand cmd)
        {
            try
            {
                _conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number >= 50000) throw new ApplicationException(ex.Message);
                throw;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open) _conexion.Close();
            }
        }
    }
}
