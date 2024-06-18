using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Redenciones
{
    public interface ICuponesRedencionRepository
    {
        
        IEnumerable<Redencion> ListarRedenciones();
        Task<bool> ValidarCupon(ReedemRequest redencionRequest, Redencion redencion);
        Task<Cupon> GetCuponByCodigo(string codigoCupon);

        
        
    }
}