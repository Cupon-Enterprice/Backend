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
    public class RedencionCuponesCreateController : ControllerBase
    {
        public readonly ICuponesRedencionRepository _Redencion;
        public RedencionCuponesCreateController(ICuponesRedencionRepository Redenciones)
        {
            _Redencion = Redenciones;
        }

        [HttpPost("api/ValidarCupon")]
        public async Task<IActionResult> ValidarCupon( ReedemRequest redencion)
        {
            var response = await _Redencion.ValidarCupon(redencion);
            if(!response){
                return BadRequest();
            }
            return Ok();
        }
    }
}
