using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
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
            var admins = _adminsRepository.ListarAdmin();
            var existe = admins.FirstOrDefault(x => x.Correo == admin.Correo);

            if (existe != null)
            {
                return BadRequest(new { message = $"El correo {admin.Correo} ya existe. Inténtelo con otro." });
            }

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