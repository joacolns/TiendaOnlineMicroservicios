using System.ComponentModel.DataAnnotations;

namespace CarritoService.Models
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<CarritoItem> Items { get; set; } = new List<CarritoItem>();
    }
}
