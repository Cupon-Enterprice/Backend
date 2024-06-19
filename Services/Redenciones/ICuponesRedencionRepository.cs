using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Redenciones
{
    public interface ICuponesRedencionRepository
    {
        
        public object ListarRedenciones([FromQuery] int? page);
        Task<bool> ValidarCupon(ReedemRequest redencionRequest, Redencion redencion);
        Task<Cupon> GetCuponByCodigo(string codigoCupon);

        
        
    }
}