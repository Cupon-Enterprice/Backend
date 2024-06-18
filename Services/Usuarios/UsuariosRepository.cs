using Backend.Data;
using Backend.Models;

namespace Backend.Services.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public readonly DataContext _context;

        public UsuariosRepository(DataContext context)
        {
            _context = context;
        }

         public IEnumerable<Usuario> ListarUsuario()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario DetallesUsuario(int Id)
        {
            return _context.Usuarios.Find(Id);
        }

        public void CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}