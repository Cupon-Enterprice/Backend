using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Cupones
{
   /* public class CuponDeleteController : ControllerBase
    {
        public readonly ICuponesRepository _cuponRepository;
        public CuponDeleteController(ICuponesRepository cuponesRepository)
        {
            _cuponRepository = cuponesRepository;
        }

        [HttpDelete("{Id}")]
        [Route("api/cupones/{Id}")]
        public IActionResult EliminarCupon(int Id)
        {
            _cuponRepository.EliminarCupon(Id);
            return Ok();
        }
    } */
}