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
        {
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
            _context.Admins.Remove(eliminar);
            _context.SaveChanges();
        }

        public IEnumerable<Admin> ListarAdmin()
        {
            return _context.Admins.ToList();
        }
    }
}