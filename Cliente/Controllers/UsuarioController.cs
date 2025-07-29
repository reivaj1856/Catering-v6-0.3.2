using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Catering.Conexion;
using Catering.Modelos;

namespace Catering.Controladores
{
    public class UsuarioController
    {
        public static List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Usuarios", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        RolId = Convert.ToInt32(reader["RolId"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Usuario u)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string sql = "INSERT INTO Usuarios (Nombre, Apellido, Correo, RolId, FechaRegistro) VALUES (@Nombre, @Apellido, @Correo, @RolId, GETDATE())";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@Correo", u.Correo);
                cmd.Parameters.AddWithValue("@RolId", u.RolId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Usuario u)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string sql = "UPDATE Usuarios SET Nombre=@Nombre, Apellido=@Apellido, Correo=@Correo, RolId=@RolId WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@Correo", u.Correo);
                cmd.Parameters.AddWithValue("@RolId", u.RolId);
                cmd.Parameters.AddWithValue("@Id", u.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Usuarios WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
