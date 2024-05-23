using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
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
            _adminsRepository.EliminarAdmin(Id);
            return Ok();
        }
    }
}