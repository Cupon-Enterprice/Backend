using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    public class AdminsActivarController : ControllerBase
    {
        public readonly IAdminsRepository _adminsRepository;
        public AdminsActivarController (IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        [HttpPatch("api/admins/{Id}")]
        public IActionResult ActivarAdmin(int Id)
        {
            
        var admin = _adminsRepository.DetallesAdmin(Id);
        if(admin == null){
            return NotFound($"no se ha encontrado usuario con el Id {Id}");
        }
            try
            {
                _adminsRepository.ActivarAdmin(Id);
                return Ok( new {message = "Se ha Activado con exito"});
            }
            catch (Exception Error)
            {
                return BadRequest(new{ message = "Error al Activar" + Error.Message});
            }
        }
    }
}