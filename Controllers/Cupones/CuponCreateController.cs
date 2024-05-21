using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponCreateController : ControllerBase
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponCreateController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        [HttpPost]
        [Route("api/cupones")]
        public IActionResult CrearCupon(Cupon cupon)
        {
            _cuponRepository.CrearCupon(cupon);
            return Ok();
        }
    }
}