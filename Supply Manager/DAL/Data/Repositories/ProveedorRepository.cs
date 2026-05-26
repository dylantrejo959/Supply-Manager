using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly SqlConnection _conexion;

        public ProveedorRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public List<Proveedor> ObtenerTodos()
        {
            return ObtenerFiltrado(null);
        }

        public List<Proveedor> ObtenerFiltrado(string nombre)
        {
            var lista = new List<Proveedor>();
            var cmd = new SqlCommand("sp_ObtenerProveedores", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(nombre) ? (object)DBNull.Value : nombre);

            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Proveedor
                    {
                        IdProveedor = Convert.ToInt32(reader["IdProveedor"]),
                        NombreProveedor = reader["NombreProveedor"].ToString(),
                        Telefono = reader["Telefono"] == DBNull.Value ? "" : reader["Telefono"].ToString(),
                        Correo = reader["Correo"] == DBNull.Value ? "" : reader["Correo"].ToString(),
                        Direccion = reader["Direccion"] == DBNull.Value ? "" : reader["Direccion"].ToString()
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

        public void Insertar(Proveedor proveedor)
        {
            var cmd = new SqlCommand("sp_InsertarProveedor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@NombreProveedor", proveedor.NombreProveedor);
            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(proveedor.Telefono) ? (object)DBNull.Value : proveedor.Telefono);
            cmd.Parameters.AddWithValue("@Correo", string.IsNullOrEmpty(proveedor.Correo) ? (object)DBNull.Value : proveedor.Correo);
            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(proveedor.Direccion) ? (object)DBNull.Value : proveedor.Direccion);
            EjecutarSinRetorno(cmd);
        }

        public void Actualizar(Proveedor proveedor)
        {
            var cmd = new SqlCommand("sp_ActualizarProveedor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
            cmd.Parameters.AddWithValue("@NombreProveedor", proveedor.NombreProveedor);
            cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(proveedor.Telefono) ? (object)DBNull.Value : proveedor.Telefono);
            cmd.Parameters.AddWithValue("@Correo", string.IsNullOrEmpty(proveedor.Correo) ? (object)DBNull.Value : proveedor.Correo);
            cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(proveedor.Direccion) ? (object)DBNull.Value : proveedor.Direccion);
            EjecutarSinRetorno(cmd);
        }

        public void Eliminar(int id)
        {
            var cmd = new SqlCommand("sp_EliminarProveedor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdProveedor", id);
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
