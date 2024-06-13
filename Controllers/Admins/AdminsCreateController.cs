using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    [ApiController]
    [Route("api/admins")]
    public class AdminsCreateController : ControllerBase
    {
        public readonly IAdminsRepository _adminsRepository;
        public AdminsCreateController (IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        [HttpPost]
        public IActionResult CrearAdmin([FromBody] Admin admin)
        {   
            try
            {
                _adminsRepository.CrearAdmin(admin);
                return Ok("Se ha creado con exito");
            }
            catch (Exception Error)
            {
                return BadRequest("Error al crear" + Error.Message);
            }
        }
    }
}