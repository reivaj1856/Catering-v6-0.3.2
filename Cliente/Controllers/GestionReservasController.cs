using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Catering.Conexion;
using Catering.Modelos;

namespace Catering.Controladores.Reservas
{
    public class GestionReservasController
    {
        public static List<Reserva> ObtenerTodos()
        {
            var lista = new List<Reserva>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Reservas", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Reserva
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                        PaqueteId = Convert.ToInt32(reader["PaqueteId"]),
                        FechaReserva = Convert.ToDateTime(reader["FechaReserva"]),
                        Hora = TimeSpan.Parse(reader["Hora"].ToString()),
                        Personas = Convert.ToInt32(reader["Personas"]),
                        Estado = reader["Estado"].ToString()
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Reserva r)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "INSERT INTO Reservas (UsuarioId, PaqueteId, FechaReserva, Hora, Personas, Estado) " +
                          "VALUES (@UsuarioId, @PaqueteId, @FechaReserva, @Hora, @Personas, @Estado)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", r.UsuarioId);
                cmd.Parameters.AddWithValue("@PaqueteId", r.PaqueteId);
                cmd.Parameters.AddWithValue("@FechaReserva", r.FechaReserva);
                cmd.Parameters.AddWithValue("@Hora", r.Hora);
                cmd.Parameters.AddWithValue("@Personas", r.Personas);
                cmd.Parameters.AddWithValue("@Estado", r.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Reserva r)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "UPDATE Reservas SET UsuarioId=@UsuarioId, PaqueteId=@PaqueteId, FechaReserva=@FechaReserva, " +
                          "Hora=@Hora, Personas=@Personas, Estado=@Estado WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", r.UsuarioId);
                cmd.Parameters.AddWithValue("@PaqueteId", r.PaqueteId);
                cmd.Parameters.AddWithValue("@FechaReserva", r.FechaReserva);
                cmd.Parameters.AddWithValue("@Hora", r.Hora);
                cmd.Parameters.AddWithValue("@Personas", r.Personas);
                cmd.Parameters.AddWithValue("@Estado", r.Estado);
                cmd.Parameters.AddWithValue("@Id", r.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Reservas WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
