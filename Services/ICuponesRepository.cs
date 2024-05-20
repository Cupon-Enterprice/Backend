using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public interface ICuponesRepository
    {
        IEnumerable<Cupon> ListarCupones();
        Cupon DetallesCupon(int Id);
        void CrearCupon(Cupon cupon);
        void EliminarCupon(int Id);
        void ActualizarCupon(int Id,Cupon cupon);
    }
}