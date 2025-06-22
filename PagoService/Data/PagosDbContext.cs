using Microsoft.EntityFrameworkCore;
using PagoService.Models;

namespace PagoService.Data
{
    public class PagosDbContext : DbContext
    {
        public PagosDbContext(DbContextOptions<PagosDbContext> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
    }
}