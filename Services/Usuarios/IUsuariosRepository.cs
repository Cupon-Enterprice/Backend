using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.Usuarios
{
    public interface IUsuariosRepository
    {
        public object ListarUsuarios([FromQuery] int? page);
        IEnumerable<Usuario> obtenerusuarios();
        Usuario DetallesUsuario(int Id);
        void CrearUsuario(Usuario Usuario);
    }
}