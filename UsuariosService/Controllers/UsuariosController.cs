using Microsoft.AspNetCore.Mvc;
using UsuariosService.Data;
using UsuariosService.Models;
using BCrypt.Net; //Para hashear contras

namespace UsuariosService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosDbContext _context;

        public UsuariosController(UsuariosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_context.Usuarios);
        }

        [HttpPost] //Para registrar usuarios
        public ActionResult RegistrarUsuarios([FromBody] UsuarioRegistroDto nuevoUsuario)
        {
            if (string.IsNullOrWhiteSpace(nuevoUsuario.NombreUsuario) || string.IsNullOrWhiteSpace(nuevoUsuario.Password))
            {
                return BadRequest("Nombre de usuarios y contraseñas son requeridos.");
            }

            //Verificar si ya existe
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nuevoUsuario.NombreUsuario);
            if(usuarioExistente != null)
            {
                return Conflict("El nombre de usuario ya está en uso.");
            }

            //Hashear contraseña
            string passwordHasheada = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Password);

            var usuario = new Usuario
            {
                NombreUsuario = nuevoUsuario.NombreUsuario,
                PasswordHashed = passwordHasheada
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, new { usuario.Id, usuario.NombreUsuario });

        }
    }
}
