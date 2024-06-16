using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Cupon
    {
        public int Id { get; set; }
        
        public string? CodigoCupon { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFinalizacion { get; set; }
        [Required]
        public double? ValorDescuento { get; set; }
        [Required]
        public int LimiteUsos { get; set; }
        [Required]
        public int Usos { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int TipoCuponId {get; set;}
        [Required]
        public int AdminId {get; set;}

        public TipoCupon? TipoCupon {get; set;}
        public Admin? Admin {get; set;}

        [JsonIgnore]
        public List<Redencion>? redenciones { get; }
    }
}