using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly SqlConnection _conexion;

        public ReporteRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public List<ReporteStockCritico> ObtenerStockCritico()
        {
            var lista = new List<ReporteStockCritico>();
            var cmd = new SqlCommand("sp_ReporteStockCritico", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ReporteStockCritico
                    {
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        UnidadMedida = reader["UnidadMedida"].ToString(),
                        StockActual = Convert.ToInt32(reader["StockActual"]),
                        StockMinimo = Convert.ToInt32(reader["StockMinimo"]),
                        Deficit = Convert.ToInt32(reader["Deficit"])
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

        public List<ReporteConsumo> ObtenerConsumo(DateTime fechaDesde, DateTime fechaHasta, int? idArea)
        {
            var lista = new List<ReporteConsumo>();
            var cmd = new SqlCommand("sp_ReporteConsumo", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
            cmd.Parameters.AddWithValue("@IdArea", idArea.HasValue ? (object)idArea.Value : DBNull.Value);
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ReporteConsumo
                    {
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        UnidadMedida = reader["UnidadMedida"].ToString(),
                        NombreArea = reader["NombreArea"].ToString(),
                        TotalConsumo = Convert.ToInt32(reader["TotalConsumo"]),
                        TotalEntradas = Convert.ToInt32(reader["TotalEntradas"])
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

        public List<ProyeccionReabastecimiento> ObtenerProyeccion()
        {
            var lista = new List<ProyeccionReabastecimiento>();
            var cmd = new SqlCommand("sp_ProyeccionReabastecimiento", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ProyeccionReabastecimiento
                    {
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        UnidadMedida = reader["UnidadMedida"].ToString(),
                        StockActual = Convert.ToInt32(reader["StockActual"]),
                        StockMinimo = Convert.ToInt32(reader["StockMinimo"]),
                        ConsumoUltimos30Dias = Convert.ToInt32(reader["ConsumoUltimos30Dias"]),
                        ConsumoPromedioDiario = Convert.ToDecimal(reader["ConsumoPromedioDiario"]),
                        DiasHastaNivelMinimo = Convert.ToInt32(reader["DiasHastaNivelMinimo"]),
                        CantidadSugeridaReorden = Convert.ToInt32(reader["CantidadSugeridaReorden"])
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
