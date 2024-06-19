using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public readonly DataContext _context;
        private readonly int records = 5;

        public UsuariosRepository(DataContext context)
        {
            _context = context;
        }

        public object ListarUsuarios([FromQuery] int? page)
        {
            int _page = page ?? 1;
            decimal totalrecords  = _context.Usuarios.Count();
            int totalpages =  Convert.ToInt32(Math.Ceiling(totalrecords/records));

            var usuarios = _context.Usuarios.Skip((_page - 1) * records).Take(records).ToList();
            var data = new {pages = totalpages, currentpage = _page, data = usuarios};

            return data;
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
        public IEnumerable<Usuario> obtenerusuarios(){
            return _context.Usuarios.ToList();
        }
    }
}