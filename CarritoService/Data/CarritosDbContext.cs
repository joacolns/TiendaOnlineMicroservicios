using CarritoService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarritoService.Data
{
    public class CarritosDbContext : DbContext
    {
        public CarritosDbContext(DbContextOptions<CarritosDbContext> options) : base(options) { }

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
    }
}