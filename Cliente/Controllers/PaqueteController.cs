using Catering.Conexion;
using Catering.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Catering.Controladores
{
    public class PaqueteController
    {
        public static List<Paquete> ObtenerTodos()
        {
            var lista = new List<Paquete>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Paquetes", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Paquete
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        ImagenURL = reader["ImagenURL"].ToString()
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Paquete p)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "INSERT INTO Paquetes (Nombre, Descripcion, Precio, ImagenURL) VALUES (@Nombre, @Descripcion, @Precio, @ImagenURL)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@ImagenURL", p.ImagenURL);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Paquete p)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "UPDATE Paquetes SET Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio, ImagenURL=@ImagenURL WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@ImagenURL", p.ImagenURL);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Paquetes WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
