using System.ComponentModel.DataAnnotations;

namespace ProductosService.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Precio { get; set; } //Decimal ofrece mas precision en los decimales que el float

        public string Descripcion { get; set; }
    }
}
