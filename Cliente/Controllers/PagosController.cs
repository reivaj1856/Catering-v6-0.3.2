using Catering.Conexion;
using Catering.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Catering.Controladores
{
    public class PagosController
    {
        public static List<Pago> ObtenerTodos()
        {
            var lista = new List<Pago>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Pagos", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Pago
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ReservaId = Convert.ToInt32(reader["ReservaId"]),
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        Metodo = reader["Metodo"].ToString(),
                        FechaPago = Convert.ToDateTime(reader["FechaPago"])
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Pago p)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                // Usamos GETDATE() para la fecha actual en SQL Server
                var sql = "INSERT INTO Pagos (ReservaId, Monto, Metodo, FechaPago) VALUES (@ReservaId, @Monto, @Metodo, GETDATE())";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ReservaId", p.ReservaId);
                cmd.Parameters.AddWithValue("@Monto", p.Monto);
                cmd.Parameters.AddWithValue("@Metodo", p.Metodo);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Pago p)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "UPDATE Pagos SET ReservaId=@ReservaId, Monto=@Monto, Metodo=@Metodo, FechaPago=@FechaPago WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ReservaId", p.ReservaId);
                cmd.Parameters.AddWithValue("@Monto", p.Monto);
                cmd.Parameters.AddWithValue("@Metodo", p.Metodo);
                cmd.Parameters.AddWithValue("@FechaPago", p.FechaPago);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Pagos WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
