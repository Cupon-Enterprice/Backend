namespace Backend.Models
{
    public class Admin{
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Clave {get; set; }

        public ICollection<Cupon>? Cupones { get; set; }
    }

}