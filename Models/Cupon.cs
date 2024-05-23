using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Cupon
    {
        
        public int Id { get; set; } //= 1;
        public string? CodigoCupon { get; set; } //= "asasd";
        public string? Nombre { get; set; } //= "jdjdjdjd";
        public string? Descripcion { get; set; } //= "fgskjfgfsdfsghhk";
        public DateTime? FechaCreacion { get; set; } //= DateTime.Now;
        public DateTime? FechaActualizacion { get; set; } //= DateTime.Now;
        public DateTime? FechaInicio { get; set; } //= DateTime.Now;
        public DateTime? FechaFinalizacion { get; set; } //= DateTime.Now;
        public double? ValorDescuento { get; set; } //= 123;
        public int? LimiteUsos { get; set; }// = 23;
        public int? Usos { get; set; } //= 32;
        public string? Estado { get; set; } 
        public int? Tipo_Cupones_Id {get; set;}
        public int? Admin_Id {get; set;}

        public TipoCupon? TipoCupon {get; set;}
        public Admin? Admin {get; set;}
    }
}