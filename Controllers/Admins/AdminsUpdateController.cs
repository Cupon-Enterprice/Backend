using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    public class AdminsUpdateController : ControllerBase
    {
        public readonly IAdminsRepository _adminsRepository;
        public AdminsUpdateController (IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        [HttpPut("api/admins/{Id}")]
        public IActionResult ActualizarAdmin(int Id, [FromBody] Admin admin)
        {
            try
            {
                _adminsRepository.ActualizarAdmin(Id, admin);
                return Ok("Se ha actualizado con exito");
            }
            catch (Exception Error)
            {
                return BadRequest("Error al actualizar" + Error.Message);
            }
        } 
    }
}