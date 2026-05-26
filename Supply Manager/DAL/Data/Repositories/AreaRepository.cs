using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Supply_Manager.Entities;
using Supply_Manager.Utils;

namespace Supply_Manager.DAL.Data.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly SqlConnection _conexion;

        public AreaRepository()
        {
            _conexion = DbConnectionSingleton.Instancia;
        }

        public List<Area> ObtenerTodas()
        {
            var lista = new List<Area>();
            var cmd = new SqlCommand("sp_ObtenerAreas", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Area
                    {
                        IdArea = Convert.ToInt32(reader["IdArea"]),
                        NombreArea = reader["NombreArea"].ToString()
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

        public void Insertar(Area area)
        {
            var cmd = new SqlCommand("sp_InsertarArea", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@NombreArea", area.NombreArea);
            EjecutarSinRetorno(cmd);
        }

        public void Actualizar(Area area)
        {
            var cmd = new SqlCommand("sp_ActualizarArea", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdArea", area.IdArea);
            cmd.Parameters.AddWithValue("@NombreArea", area.NombreArea);
            EjecutarSinRetorno(cmd);
        }

        public void Eliminar(int id)
        {
            var cmd = new SqlCommand("sp_EliminarArea", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdArea", id);
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
