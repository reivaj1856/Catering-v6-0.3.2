using System;

namespace Catering.Modelos
{
    public class Pago
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; } // QR, PayPal, Transferencia
        public DateTime FechaPago { get; set; }
    }
}
