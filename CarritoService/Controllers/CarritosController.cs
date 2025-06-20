using CarritoService.Data;
using CarritoService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarritoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritosController : ControllerBase
    {
        private readonly CarritosDbContext _context;

        public CarritosController(CarritosDbContext context)
        {
            _context = context;
        }

        [HttpGet("{usuarioId}")]
        public ActionResult<Carrito> GetCarrito(int usuarioId)
        {
            var carrito = _context.Carritos
                .Where(c => c.UsuarioId == usuarioId)
                .Include(c => c.Items)
                .FirstOrDefault();
            return carrito is not null ? Ok(carrito) : NotFound();
        }

        [HttpPost("{usuarioId}/items")]
        public ActionResult AgregarItem(int usuarioId, [FromBody] CarritoItem nuevoItem)
        {
            var carrito = _context.Carritos
                .Include(c => c.Items)
                .FirstOrDefault(c => c.UsuarioId == usuarioId);

            if (carrito == null)
            {
                carrito = new Carrito { UsuarioId = usuarioId };
                _context.Carritos.Add(carrito);
            }

            carrito.Items.Add(nuevoItem);
            _context.SaveChanges();
            return Ok(carrito);
        }

        [HttpDelete("{usuarioId}/items/{itemId}")]
        public ActionResult EliminarItem(int usuarioId, int itemId)
        {
            var carrito = _context.Carritos
                .Include(c => c.Items)
                .FirstOrDefault(c => c.UsuarioId == usuarioId);

            if (carrito is null) return NotFound();

            var item = carrito.Items.FirstOrDefault(i => i.Id == itemId);
            if (item is not null)
            {
                carrito.Items.Remove(item);
                _context.SaveChanges();
            }

            return NoContent();
        }
    }
}