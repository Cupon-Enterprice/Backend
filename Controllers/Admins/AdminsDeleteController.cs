using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    public class AdminsDeleteController : ControllerBase
    {
        public readonly IAdminsRepository _adminsRepository;
        public AdminsDeleteController (IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        [HttpDelete("api/admins/{Id}")]
        public IActionResult EliminarAdmin(int Id)
        {
            try
            {
                _adminsRepository.EliminarAdmin(Id);
                return Ok("Se ha eliminado con exito");
            }
            catch (Exception Error)
            {
                return BadRequest("Error al eliminar" + Error.Message);
            }
        }
    }
}