using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Cupones
{
    public interface ICuponesRepository
    {
        public object ListarCupones([FromQuery] int? page);
        Cupon DetallesCupon(int Id);
        void CrearCupon(Cupon cupon);
        void EliminarCupon(int Id);
        void ActualizarCupon(int Id,Cupon cupon);
        void ActivarCupon(int Id);
    }
}