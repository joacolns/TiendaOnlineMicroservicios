using Microsoft.AspNetCore.Mvc;
using PagoService.Data;
using PagoService.Models;
using Microsoft.EntityFrameworkCore;

namespace PagoService.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly PagosDbContext _context;

        public PagosController(PagosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pago>> GetAll()
        {
            return Ok(_context.Pagos);
        }

        [HttpGet("{id}")]
        public ActionResult<Pago> GetPago(int id)
        {
            var pago = _context.Pagos.Find(id);
            return pago is not null ? Ok(pago) : NotFound();
        }

        [HttpPost]
        public ActionResult<Pago> CrearPago([FromBody] Pago nuevoPago)
        {
            _context.Pagos.Add(nuevoPago);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPago), new { id = nuevoPago.Id }, nuevoPago);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarPago(int id)
        {
            var pagoAEliminar = _context.Pagos.Find(id);
            if (pagoAEliminar is null) return NotFound();

            _context.Pagos.Remove(pagoAEliminar);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
