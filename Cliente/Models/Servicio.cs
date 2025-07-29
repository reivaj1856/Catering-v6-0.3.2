namespace Catering.Modelos
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; } // Ej: mantelería, mobiliario, bartender, etc.
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
