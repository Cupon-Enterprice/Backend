using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
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

        [HttpPut("api/cupon/{Id}")]
        public void ActualizarCupon(int Id, [FromBody] Cupon cupon) => _cuponRepository.ActualizarCupon(Id, cupon);
    }
}