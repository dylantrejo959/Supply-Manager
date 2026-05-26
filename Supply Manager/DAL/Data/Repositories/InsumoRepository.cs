using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class InsumoRepository : IInsumoRepository
    {
        private readonly SqlConnection _conexion;

        public InsumoRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public List<Insumo> ObtenerTodos()
        {
            return ObtenerFiltrado(null, null, false);
        }

        public List<Insumo> ObtenerFiltrado(string nombre, string unidadMedida, bool soloStockCritico)
        {
            var lista = new List<Insumo>();
            var cmd = new SqlCommand("sp_ObtenerInsumos", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(nombre) ? (object)DBNull.Value : nombre);
            cmd.Parameters.AddWithValue("@UnidadMedida", string.IsNullOrWhiteSpace(unidadMedida) ? (object)DBNull.Value : unidadMedida);
            cmd.Parameters.AddWithValue("@SoloStockCritico", soloStockCritico ? 1 : 0);

            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Insumo
                    {
                        IdInsumo = Convert.ToInt32(reader["IdInsumo"]),
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        StockActual = Convert.ToInt32(reader["StockActual"]),
                        StockMinimo = Convert.ToInt32(reader["StockMinimo"]),
                        UnidadMedida = reader["UnidadMedida"].ToString(),
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

        public void Insertar(Insumo insumo)
        {
            var cmd = new SqlCommand("sp_InsertarInsumo", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@NombreInsumo", insumo.NombreInsumo);
            cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(insumo.Descripcion) ? (object)DBNull.Value : insumo.Descripcion);
            cmd.Parameters.AddWithValue("@StockActual", insumo.StockActual);
            cmd.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
            cmd.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida);
            EjecutarSinRetorno(cmd);
        }

        public void Actualizar(Insumo insumo)
        {
            var cmd = new SqlCommand("sp_ActualizarInsumo", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdInsumo", insumo.IdInsumo);
            cmd.Parameters.AddWithValue("@NombreInsumo", insumo.NombreInsumo);
            cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(insumo.Descripcion) ? (object)DBNull.Value : insumo.Descripcion);
            cmd.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
            cmd.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida);
            EjecutarSinRetorno(cmd);
        }

        public void Desactivar(int id)
        {
            var cmd = new SqlCommand("sp_DesactivarInsumo", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdInsumo", id);
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
