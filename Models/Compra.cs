namespace Backend.Models{
    public class Compra{
        public int? Id { get; set;}
        public DateOnly? Fecha {get; set;}
        public int? Cantidad {get; set;}
        public int? UsuarioId {get; set;}
        public Usuario? Usuario {get; set;}
    }
}