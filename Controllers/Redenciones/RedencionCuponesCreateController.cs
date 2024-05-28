using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Redenciones
{
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
            Console.WriteLine("reuqest pa", redencion.UsuarioId);
            await _Redencion.ValidarCupon(redencion);
            return Ok();
        }
    }
}
