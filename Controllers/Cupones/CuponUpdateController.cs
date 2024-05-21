using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponUpdateController : ControllerBase
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponUpdateController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        // [HttpPut("{Id}")]
        // [Route("api/cupones/{Id}")]
        // public string ActualizarCupon(int Id , Cupon cupon)
        // {
        //     _cuponRepository.ActualizarCupon(Id, cupon);
        //     return ;
        // }
    }
}