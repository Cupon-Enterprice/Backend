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

        [HttpPost]
        [Route("api/ValidarCupon")]
        public IActionResult ValidarCupon([FromBody] ReedemRequest redencion)
        {
            _Redencion.ValidarCupon(redencion.UsuariosId,redencion.CodigoCupon);
            return Ok();
        }
    }
}
