using Microsoft.AspNetCore.Mvc;
using PedidosService.Data;
using PedidosService.Models;
using Microsoft.EntityFrameworkCore;

namespace PedidosService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public PedidosController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetAll()
        {
            return Ok(_context.Pedidos);
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            return pedido is not null ? Ok(pedido) : NotFound();
        }

        [HttpPost]
        public ActionResult<Pedido> CrearPedido([FromBody] Pedido nuevoPedido)
        {
            _context.Pedidos.Add(nuevoPedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CrearPedido), new { id = nuevoPedido.Id }, nuevoPedido);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarPedido(int id)
        {
            var pedidoAEliminar = _context.Pedidos.Find(id);
            if (pedidoAEliminar is null) return NotFound();

            _context.Pedidos.Remove(pedidoAEliminar);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
