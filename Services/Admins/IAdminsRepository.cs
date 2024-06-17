using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Admins
{
    public interface IAdminsRepository
    {
        IEnumerable<Admin> ListarAdmin();
        Admin DetallesAdmin(int Id);
        void CrearAdmin(Admin admin);
        void EliminarAdmin(int Id);
        void ActualizarAdmin(int Id,Admin admin);
        void ActivarAdmin(int Id);
    }

}