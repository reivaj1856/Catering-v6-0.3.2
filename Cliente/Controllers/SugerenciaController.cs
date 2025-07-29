using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Catering.Conexion;
using Catering.Modelos;

namespace Catering.Controladores
{
    public class SugerenciaController
    {
        public static List<Sugerencia> ObtenerTodas()
        {
            var lista = new List<Sugerencia>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Sugerencias", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Sugerencia
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                        Comentario = reader["Comentario"].ToString(),
                        FechaEnvio = Convert.ToDateTime(reader["FechaEnvio"])
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Sugerencia s)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "INSERT INTO Sugerencias (UsuarioId, Comentario, FechaEnvio) VALUES (@UsuarioId, @Comentario, GETDATE())";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", s.UsuarioId);
                cmd.Parameters.AddWithValue("@Comentario", s.Comentario);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Sugerencia s)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "UPDATE Sugerencias SET UsuarioId=@UsuarioId, Comentario=@Comentario WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", s.UsuarioId);
                cmd.Parameters.AddWithValue("@Comentario", s.Comentario);
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Sugerencias WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
