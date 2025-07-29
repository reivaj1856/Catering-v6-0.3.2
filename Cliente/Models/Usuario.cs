using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catering.Conexion
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int RolId { get; set; }
        public DateTime FechaRegistro { get; set; } // Propiedad agregada
    }

}