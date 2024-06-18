using Backend.Data;
using Backend.Models;

namespace Backend.Services.Admins
{
    public class AdminsRepository : IAdminsRepository
    {
        public readonly DataContext _context;

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

        public IEnumerable<Admin> ListarAdmin()
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