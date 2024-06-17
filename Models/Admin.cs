using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Admin{
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre is required")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Correo is required")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Clave is required")]
        public string Clave {get; set; }
        [Required(ErrorMessage = "Estado is required")]
        public string Estado {get; set;}
        [JsonIgnore]
        public List<Cupon>? Cupones { get; }
    }

}