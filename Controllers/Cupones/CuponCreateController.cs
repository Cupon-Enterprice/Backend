// Controllers/CuponCreateController.cs
using System;
using Backend.Models;
using Backend.Services.Cupones;
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
            if(cupon.AdminId == null){
                return BadRequest(new { message = $"El {cupon.AdminId} para el admin no fue encontrado " });
            }
            try
            {
                string codigoCupon = _cuponService.GenerateRandomCuponCode();
                cupon.CodigoCupon = codigoCupon;
                _cuponRepository.CrearCupon(cupon);
                return Ok(new {message = $"se ha creado con exito"});
            }
            catch (Exception Error)
            {
                return BadRequest(new { message = "Error al crear" + Error.Message});
            }
        }
    }
}
