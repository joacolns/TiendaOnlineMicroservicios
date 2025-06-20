using Microsoft.AspNetCore.Mvc;
using UsuariosService.Data;
using UsuariosService.Models;

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
    }
}
