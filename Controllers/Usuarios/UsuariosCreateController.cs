using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosCreateController : ControllerBase
    {
        public readonly IUsuariosRepository _usuariosRepository;
        public UsuariosCreateController (IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {  
            var usuarios = _usuariosRepository.ListarUsuario();
            var existe = usuarios.FirstOrDefault(x => x.Correo == usuario.Correo);

            if (existe != null)
            {
                return BadRequest(new { message = $"El correo {usuario.Correo} ya existe. Inténtelo con otro." });
            }

            try
            {
                _usuariosRepository.CrearUsuario(usuario);
                return Ok("Se ha creado con exito");
            }
            catch (Exception Error)
            {
                return BadRequest("Error al crear" + Error.Message);
            }
        }
    }
}