using Catering.Conexion;
using Catering.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Catering.Controladores
{
    public class ServiciosController
    {
        public static List<Servicio> ObtenerTodos()
        {
            var lista = new List<Servicio>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM Servicios", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Servicio
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Categoria = reader["Categoria"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"])
                    });
                }
            }
            return lista;
        }

        public static void Insertar(Servicio s)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "INSERT INTO Servicios (Nombre, Categoria, Descripcion, Precio) VALUES (@Nombre, @Categoria, @Descripcion, @Precio)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", s.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", s.Categoria);
                cmd.Parameters.AddWithValue("@Descripcion", s.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", s.Precio);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(Servicio s)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var sql = "UPDATE Servicios SET Nombre=@Nombre, Categoria=@Categoria, Descripcion=@Descripcion, Precio=@Precio WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", s.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", s.Categoria);
                cmd.Parameters.AddWithValue("@Descripcion", s.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", s.Precio);
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                var cmd = new SqlCommand("DELETE FROM Servicios WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
