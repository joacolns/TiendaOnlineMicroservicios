using Microsoft.EntityFrameworkCore;
using PedidosService.Models;

namespace PedidosService.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
