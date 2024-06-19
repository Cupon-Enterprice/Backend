using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Cupones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponActivarController : ControllerBase
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponActivarController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        [HttpPatch("api/cupones/{Id}")]
        public IActionResult ActivarCupon(int Id)
        {
        var cupon = _cuponRepository.DetallesCupon(Id);
        if(cupon == null){
            return NotFound(new { message = $"no se ha encontrado cupon  con el Id {Id}" });
        }
            try
            {
                _cuponRepository.ActivarCupon(Id);
                return Ok(new { message = "Se ha activado el cupon con éxito"});
            }
            catch (Exception Error)
            {
                return BadRequest(new { message = "Error al Activar el cupon" + Error.Message});
            }
        }
    }
}