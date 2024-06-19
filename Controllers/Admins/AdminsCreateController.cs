using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
using Backend.Services.Slack;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    [ApiController]
    [Route("api/admins")]
    public class AdminsCreateController : ControllerBase
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly ISlackService _slackService;

        public AdminsCreateController(IAdminsRepository adminsRepository, ISlackService slackService)
        {
            _adminsRepository = adminsRepository;
            _slackService = slackService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearAdmin([FromBody] Admin admin)
        {  
            var admins = _adminsRepository.ObtenerAdmins();
            var existe = admins.FirstOrDefault(x => x.Correo == admin.Correo);

            if (existe != null)
            {
                return BadRequest(new { message = $"El correo {admin.Correo} ya existe. Inténtelo con otro." });
            }

            try
            {
                _adminsRepository.CrearAdmin(admin);
                return Ok("Se ha creado con éxito");
            }
            catch (Exception ex)
            {
                
                await _slackService.SendMessageAsync($"se ha generado un eror {ex}");

                
                return BadRequest("Error al crear: " + ex.Message);
            }
        }
    }
}