using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Usuarios
{
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuariosRepository _usuariosRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        [Route("api/usuarios")]
        public IEnumerable<Usuario> ListarUsuario()
        {
            return _usuariosRepository.ListarUsuario();
        }

        [HttpGet]
        [Route("api/Usuarios/{Id}")]
        public IActionResult Detalles(int Id)
        {
            try
            {
                var usuarios = _usuariosRepository.DetallesUsuario(Id);
                if (usuarios == null)
                {
                    return NotFound(new { message = $"No se encuentra el usuario con el id {Id}" });
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al crear" + ex.Message);
            }
        }
    }
}