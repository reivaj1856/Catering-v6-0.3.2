using Catering.Conexion;
using Catering.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Catering.Controladores
{
    public class GestionReservasController
    {
        public static List<Reserva> ObtenerTodos()
        {
            var lista = new List<Reserva>();

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                using (var cmd = new SqlCommand("SELECT * FROM Reservas", conn))
                using (var reader = cmd.ExecuteReader())
                {
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
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error o lanzarlo si lo quieres manejar en otra capa
                throw new Exception("Error al obtener las reservas: " + ex.Message);
            }

            return lista;
        }

        public static void Insertar(Reserva r)
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"INSERT INTO Reservas (UsuarioId, PaqueteId, FechaReserva, Hora, Personas, Estado) 
                      VALUES (@UsuarioId, @PaqueteId, @FechaReserva, @Hora, @Personas, @Estado)", conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", r.UsuarioId);
                    cmd.Parameters.AddWithValue("@PaqueteId", r.PaqueteId);
                    cmd.Parameters.AddWithValue("@FechaReserva", r.FechaReserva);
                    cmd.Parameters.AddWithValue("@Hora", r.Hora);
                    cmd.Parameters.AddWithValue("@Personas", r.Personas);
                    cmd.Parameters.AddWithValue("@Estado", r.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la reserva: " + ex.Message);
            }
        }

        public static void Actualizar(Reserva r)
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"UPDATE Reservas 
                      SET UsuarioId = @UsuarioId, 
                          PaqueteId = @PaqueteId, 
                          FechaReserva = @FechaReserva, 
                          Hora = @Hora, 
                          Personas = @Personas, 
                          Estado = @Estado 
                      WHERE Id = @Id", conn))
                {
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
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva: " + ex.Message);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                using (var cmd = new SqlCommand("DELETE FROM Reservas WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva: " + ex.Message);
            }
        }
    }
}
