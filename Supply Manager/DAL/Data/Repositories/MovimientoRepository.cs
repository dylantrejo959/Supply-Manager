using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly SqlConnection _conexion;

        public MovimientoRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public void Registrar(Movimiento movimiento)
        {
            var cmd = new SqlCommand("sp_RegistrarMovimiento", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
            cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
            cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrEmpty(movimiento.Observacion) ? (object)DBNull.Value : movimiento.Observacion);
            cmd.Parameters.AddWithValue("@IdInsumo", movimiento.IdInsumo);
            cmd.Parameters.AddWithValue("@IdArea", movimiento.IdArea);
            cmd.Parameters.AddWithValue("@IdUsuario", movimiento.IdUsuario);

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

        public List<MovimientoDetalle> ObtenerFiltrado(int? idInsumo, int? idArea, string tipoMovimiento, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            var lista = new List<MovimientoDetalle>();
            var cmd = new SqlCommand("sp_ObtenerMovimientos", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdInsumo", idInsumo.HasValue ? (object)idInsumo.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IdArea", idArea.HasValue ? (object)idArea.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@TipoMovimiento", string.IsNullOrWhiteSpace(tipoMovimiento) ? (object)DBNull.Value : tipoMovimiento);
            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.HasValue ? (object)fechaDesde.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.HasValue ? (object)fechaHasta.Value : DBNull.Value);

            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new MovimientoDetalle
                    {
                        IdMovimiento = Convert.ToInt32(reader["IdMovimiento"]),
                        TipoMovimiento = reader["TipoMovimiento"].ToString(),
                        FechaMovimiento = Convert.ToDateTime(reader["FechaMovimiento"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        Observacion = reader["Observacion"] == DBNull.Value ? "" : reader["Observacion"].ToString(),
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        NombreArea = reader["NombreArea"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString()
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
    }
}
