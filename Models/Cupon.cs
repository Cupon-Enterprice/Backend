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
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public double? ValorDescuento { get; set; }
        public int? LimiteUsos { get; set; }
        public int? Usos { get; set; }
        public string? Estado { get; set; }
        public int? TipoCuponId {get; set;}
        public int? AdminId {get; set;}

        public TipoCupon? TipoCupon {get; set;}
        public Admin? Admin {get; set;}

        [JsonIgnore]
        public List<Redencion>? redenciones { get; }
    }
}