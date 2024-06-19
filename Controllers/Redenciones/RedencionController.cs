using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Redenciones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Redenciones
{
    public class RedencionListarController : ControllerBase
    {
        public readonly ICuponesRedencionRepository _Redencion;
        public RedencionListarController(ICuponesRedencionRepository Redenciones)
        {
            _Redencion = Redenciones;
        }

        [HttpGet]
        [Route("api/redencion")]
        public object ListarRedenciones([FromQuery] int? page)
        {
            return _Redencion.ListarRedenciones(page);
        }
        
    }
}


