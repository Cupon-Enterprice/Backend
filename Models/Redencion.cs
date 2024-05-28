namespace Backend.Models{
    public class Redencion{
        public int? Id { get; set;}
        public DateTime? FechaRendencion{get; set;} = DateTime.Now;
        public int? CuponId {get; set;}
        public int? UsuarioId {get; set;}

        public Cupon Cupones {get;}
        
    }
}