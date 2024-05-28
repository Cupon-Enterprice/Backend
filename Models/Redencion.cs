namespace Backend.Models{
    public class Redencion{
        public int? Id { get; set;}
        public DateTime? FechaRendencion{get; set;} = DateTime.Now;
        public int? CuponesId {get; set;}
        public int? UsuariosId {get; set;}

        public Cupon Cupones {get;}
        
    }
}