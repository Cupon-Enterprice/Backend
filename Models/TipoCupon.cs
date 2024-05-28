using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class TipoCupon{
        public int Id { get; set; }
        public string? Tipo { get; set; }

        [JsonIgnore]
        public List<Cupon>? Cupones {get;}
    }
}