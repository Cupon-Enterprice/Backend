using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Admins;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    public class AdminsController : ControllerBase
    {
        public readonly IAdminsRepository _adminRepository;

        public AdminsController(IAdminsRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("api/admins")]
        public object ListarAdmin([FromQuery] int? page)
        {
            return _adminRepository.ListarAdmins(page);
        }

        [HttpGet]
        [Route("api/admins/{Id}")]
        public IActionResult Detalles(int Id)
        {
            try
            {
                var admin = _adminRepository.DetallesAdmin(Id);
                if (admin == null)
                {
                    return NotFound(new { message = $"No se encuentra el admin con el id {Id}" });
                }
                return Ok(admin);
            }
            catch (Exception ex)
            {
                

                return BadRequest("Error al crear" + ex.Message);
            }
        }

            }
}