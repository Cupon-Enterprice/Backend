namespace Backend.Models{
    public class Redencion{
        public int Id { get; set;}
        public Datetime FechaRendencion{get; set;}
        public int CuponesId {get; set;}
        public int UsuariosId {get; set;}
        
    }
}