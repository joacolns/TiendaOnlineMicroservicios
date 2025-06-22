using Microsoft.AspNetCore.Mvc;
using ProductosService.Data;
using ProductosService.Models;

namespace ProductosService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosDbContext _context;

        public ProductosController(ProductosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProducto()
        {
            return Ok(_context.Productos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetProductoById(int id)
        {
            var producto = _context.Productos.Find(id);
            return producto is not null ? Ok(producto) : NotFound();
        }

        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto nuevoProducto)
        {
            _context.Productos.Add(nuevoProducto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductoById), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            //if (producto is null) return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
