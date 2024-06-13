using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Admin{
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre is required")]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave {get; set; }
        [JsonIgnore]
        public List<Cupon>? Cupones { get; }
    }

}