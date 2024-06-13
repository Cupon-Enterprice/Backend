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
        public IEnumerable<Admin> ListarAdmins()
        {
            return _adminRepository.ListarAdmin();
        }

        [HttpGet]
        [Route("api/admins/{Id}")]
        public Admin Detalles (int Id){
            return _adminRepository.DetallesAdmin(Id);
        }
    }
}