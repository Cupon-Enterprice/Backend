using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Cupones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
    public class CuponDeleteController : ControllerBase
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponDeleteController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        [HttpDelete("api/cupones/{Id}")]
        public IActionResult EliminarCupon(int Id)
        {
        var cupon = _cuponRepository.DetallesCupon(Id);
        if(cupon == null){
            return NotFound(new { message = $"no se ha encontrado cupon  con el Id {Id}" });
        }
            try
            {
                _cuponRepository.EliminarCupon(Id);
                return Ok(new { message = "Se ha eliminado con exito"});
            }
            catch (Exception Error)
            {
                return BadRequest(new { message = "Error al eliminar" + Error.Message});
            }
        }
    }
}