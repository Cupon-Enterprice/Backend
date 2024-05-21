using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponController
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        [HttpGet]
        [Route("api/cupones")]
        public IEnumerable<Cupon> ListarCupones()
        {
            return _cuponRepository.ListarCupones();
        }

        [HttpGet]
        [Route("api/users/{Id}")]
        public Cupon Details(int Id){
            return _cuponRepository.DetallesCupon(Id);
        }
    }
}