// Controllers/CuponCreateController.cs
using System;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    [ApiController]
    [Route("api/cupones")]
    public class CuponCreateController : ControllerBase
    {
        private readonly ICuponesRepository _cuponRepository;
        private readonly CuponService _cuponService;

        public CuponCreateController(ICuponesRepository cuponesRepository, CuponService cuponService)
        {
            _cuponRepository = cuponesRepository;
            _cuponService = cuponService;
        }

        [HttpPost]
        public IActionResult CrearCupon([FromBody] Cupon cupon)
        {
            
            string codigoCupon = _cuponService.GenerateRandomCuponCode();
            cupon.CodigoCupon = codigoCupon;
            _cuponRepository.CrearCupon(cupon);

            return Ok(cupon);
        }
    }
}
