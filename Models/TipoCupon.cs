namespace Backend.Models
{
    public class TipoCupon{
        public int Id { get; set; }
        public string? Tipo { get; set; }

        public ICollection<Cupon> Cupones {get;}
    }
}