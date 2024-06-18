using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Usuarios
{
    public interface IUsuariosRepository
    {
        IEnumerable<Usuario> ListarUsuario();
        Usuario DetallesUsuario(int Id);
        void CrearUsuario(Usuario Usuario);
    }
}