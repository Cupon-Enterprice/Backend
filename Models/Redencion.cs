namespace Backend.Models{
    public class Redencion{
        public int? Id { get; set;}
        public DateTime? FechaRendencion{get; set;} = DateTime.Now;
        public int? CuponesId {get; set;} = 1;
        public int? UsuariosId {get; set;} =1;

        public Cupon Cupones {get;}
        public Usuario Usuarios {get;}
        
    }
}