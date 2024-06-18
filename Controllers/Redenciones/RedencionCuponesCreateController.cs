using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Redenciones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Redenciones
{
   [ApiController]
    [Route("api/[controller]")]
    public class RedencionCuponesCreateController : ControllerBase
    {
        private readonly ICuponesRedencionRepository _redencionRepository;

        public RedencionCuponesCreateController(ICuponesRedencionRepository redencionRepository)
        {
            _redencionRepository = redencionRepository;
        }

        [HttpPost("validarCupon")]
        public async Task<IActionResult> ValidarCupon([FromBody] ReedemRequest redencionRequest)
        {
            if (string.IsNullOrEmpty(redencionRequest.CodigoCupon))
            {
                return BadRequest(new { message = "El código del cupón no puede estar vacío" });
            }

            
            var cupon = await _redencionRepository.GetCuponByCodigo(redencionRequest.CodigoCupon);
            if (cupon == null)
            {
                return BadRequest(new { message = "El cupón no existe" });
            }

            
            var redencion = new Redencion
            {
                UsuarioId = redencionRequest.UsuarioId,
                CuponId = cupon.Id,
                FechaRendencion = DateTime.Now
            };

            var response = await _redencionRepository.ValidarCupon(redencionRequest, redencion);

            if (!response)
            {
                return BadRequest(new { message = "La validación del cupón falló" });
            }

            return Ok(new { message = "El cupón se ha validado con éxito" });
        }
    }
}
