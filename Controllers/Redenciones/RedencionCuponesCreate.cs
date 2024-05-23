using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Redenciones
{
public class RedencionController : ControllerBase
    {
        public readonly ICuponesRedencionRepository _Redencion;
        public RedencionController(ICuponesRedencionRepository Redenciones)
        {
            _Redencion = Redenciones;
        }

        [HttpPost]
        [Route("api/Redencion")]
        public IActionResult CrearCupon(Redencion redencion)
        {
            _Redencion.CrearRedencion(redencion);
            return Ok();
        }
    }
}
