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
            var adminsss = _adminsRepository.ListarAdmin();
            var existe = adminsss.Where(x => x.Correo == admin.Correo).FirstOrDefault();
            if (existe!= null)
            {
                return BadRequest($"El correo {admin.Correo} ya existe intentelo con otro");
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