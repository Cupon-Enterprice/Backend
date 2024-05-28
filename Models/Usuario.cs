namespace Backend.Models
{
    public class Usuario{
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int CuponesId { get; set; }
        
        public ICollection<Redencion>? redenciones { get; }
    }
}