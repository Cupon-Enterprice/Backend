using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Admins
{
    public class AdminsRepository : IAdminsRepository
    {
        public readonly DataContext _context;

        private readonly int records = 5;

        public AdminsRepository(DataContext context)
        {
            _context = context;
        }

        public void ActualizarAdmin(int Id, Admin admin)
        {
            admin.Id = Id;
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }

        public void CrearAdmin(Admin admin)
        {   admin.Estado = "Activo";
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public Admin DetallesAdmin(int Id)
        {
            return _context.Admins.Find(Id);
        }

        public void EliminarAdmin(int Id)
        {
            var eliminar = _context.Admins.Find(Id);
            eliminar.Estado = "Inactivo";
            _context.Admins.Update(eliminar);
            _context.SaveChanges();
        }

        public object ListarAdmins([FromQuery] int? page)
        {
            int _page = page ?? 1;
            decimal totalrecords = _context.Admins.Count();
            int totalpages = Convert.ToInt32(Math.Ceiling(totalrecords/records));

            var admins = _context.Admins.Skip((_page - 1) * records).Take(records).ToList();
            var data = new {pages = totalpages, currentpage = _page, data = admins};
            return data;
        }
        public IEnumerable<Admin> ObtenerAdmins()
        {
            return _context.Admins.ToList();
        }

        public void ActivarAdmin(int Id){
            var activar = _context.Admins.Find(Id);
            activar.Estado = "Activo";
            _context.Update(activar);
            _context.SaveChanges();
            
        }
    }
}