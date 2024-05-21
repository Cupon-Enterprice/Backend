using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpDelete("{id}")]
        [Route("api/cupones/{id}")]
        public IActionResult EliminarCupon(int id)
        {
            _cuponRepository.EliminarCupon(id);
            return Ok();
        }
    }
}