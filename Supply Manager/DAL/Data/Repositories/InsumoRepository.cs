using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Manager.Entities;
using Supply_Manager.Utils;
using System.Data.SqlClient;

namespace Supply_Manager.Data.Repositories
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
            List<Insumo> lista = new List<Insumo>();

            SqlCommand comando =
                new SqlCommand("SELECT * FROM Insumos", _conexion);

            try
            {
                _conexion.Open();

                SqlDataReader reader =
                    comando.ExecuteReader();

                while (reader.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = Convert.ToInt32(reader["IdInsumo"]),
                        NombreInsumo = reader["NombreInsumo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        StockActual = Convert.ToInt32(reader["StockActual"]),
                        StockMinimo = Convert.ToInt32(reader["StockMinimo"]),
                        UnidadMedida = reader["UnidadMedida"].ToString()
                    };

                    lista.Add(insumo);
                }

                reader.Close();

                return lista;
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        public void Insertar(Insumo insumo)
        {
            SqlCommand comando = new SqlCommand(
                "INSERT INTO Insumos(NombreInsumo,Descripcion,StockActual,StockMinimo,UnidadMedida)" +
                "VALUES(@Nombre,@Descripcion,@Stock,@StockMinimo,@Unidad)",
                _conexion
            );

            comando.Parameters.AddWithValue("@Nombre", insumo.NombreInsumo);
            comando.Parameters.AddWithValue("@Descripcion", insumo.Descripcion);
            comando.Parameters.AddWithValue("@Stock", insumo.StockActual);
            comando.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
            comando.Parameters.AddWithValue("@Unidad", insumo.UnidadMedida);

            try
            {
                _conexion.Open();

                comando.ExecuteNonQuery();
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        public void Actualizar(Insumo insumo)
        {

        }

        public void Eliminar(int id)
        {

        }
    }
}