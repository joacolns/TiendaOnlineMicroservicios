using System.ComponentModel.DataAnnotations;

namespace CarritoService.Models
{
    public class CarritoItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}