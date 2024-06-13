using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Admins
{
    public class AdminsCreateController : ControllerBase
    {
        public readonly IAdminsRepository _adminsRepository;
        public AdminsCreateController (IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        [HttpPost]
        [Route("api/admins/")]
        public IActionResult CrearAdmin([FromBody]Admin admin)
        {
            _adminsRepository.CrearAdmin(admin);
            return Ok();
        }
    }
}