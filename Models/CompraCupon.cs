namespace Backend.Models{
    public class CompraCupon{
        public int Id { get; set; }
        public int? CuponId { get; set; } 
        public int? CompraId { get; set; }
        public  Cupon? Cupon { get; set; }
        public Compra? Compra { get; set; }
        
    }
}