using System;

namespace Catering.Modelos
{
    public class Sugerencia
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
