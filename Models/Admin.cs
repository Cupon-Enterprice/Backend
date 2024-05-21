namespace Backend.Models
{
    public class Admin{
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña {get; set; }

        //public ICollection<Cupon> Cupones { get; }
    }

}