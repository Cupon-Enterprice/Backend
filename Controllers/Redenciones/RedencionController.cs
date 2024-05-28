using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
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
        [Route("api/Redencion")]
        public IEnumerable<Redencion> ListarCupones()
        {
            return _Redencion.ListarRedenciones();
        }

        


        
    }
}


