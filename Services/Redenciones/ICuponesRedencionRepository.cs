using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Redenciones
{
    public interface ICuponesRedencionRepository
    {
        void CrearRedencion(Redencion redencion);
        IEnumerable<Redencion> ListarRedenciones();
        Task<bool> ValidarCupon(ReedemRequest redencion);
        
    }
}