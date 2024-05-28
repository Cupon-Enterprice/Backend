using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Usuario{
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int? CuponesId { get; set; }
        
        [JsonIgnore]
        public List<Redencion>? redenciones { get; }
    }
}