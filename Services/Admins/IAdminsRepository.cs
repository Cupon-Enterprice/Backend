using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Admins
{
    public interface IAdminsRepository
    {
        public object ListarAdmins([FromQuery] int? page);
        IEnumerable<Admin> ObtenerAdmins();
        Admin DetallesAdmin(int Id);
        void CrearAdmin(Admin admin);
        void EliminarAdmin(int Id);
        void ActualizarAdmin(int Id,Admin admin);
        void ActivarAdmin(int Id);
    }

}