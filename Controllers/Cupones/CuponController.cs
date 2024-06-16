using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Cupones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponController : ControllerBase
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
        [Route("api/cupones/{Id}")]
        public IActionResult DetallesCupon( int Id)
        {
            try
            {
                var cupon = _cuponRepository.DetallesCupon(Id);
                if (cupon == null)
                {
                    return NotFound(new { message = $"No se encuentra el cupon  con el id {Id}" });
                }
                return Ok(cupon);
            }
            catch (Exception ex)
            {


                return BadRequest("Error al crear" + ex.Message);
            }
        }
    }
}