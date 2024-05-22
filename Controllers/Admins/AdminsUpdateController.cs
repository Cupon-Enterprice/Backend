using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
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
        public void ActualizarAdmin(int Id, [FromBody] Admin admin) => _adminsRepository.ActualizarAdmin(Id, admin);
    }
}