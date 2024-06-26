using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Cupones;
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

        [HttpPut("api/cupones/{Id}")]
        public IActionResult ActualizarCupon(int Id, [FromBody] Cupon cupon)
        {
            try
            {
                _cuponRepository.ActualizarCupon(Id, cupon);
                return Ok(new { message = "Se ha actualizado con exito"});
            }
            catch (Exception Error)
            {
                return BadRequest(new { mesagge= "Error al actualizar" + Error.Message});
            }
        }
    }
}