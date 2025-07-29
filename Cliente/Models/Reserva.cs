using System;

namespace Catering.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PaqueteId { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan Hora { get; set; }
        public int Personas { get; set; }
        public string Estado { get; set; } // Pendiente, Confirmada, Pagada
    }
}
