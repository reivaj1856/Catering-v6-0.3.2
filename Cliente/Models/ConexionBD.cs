using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Catering.Conexion
{
    public class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ConexionCatering"].ConnectionString;
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}
