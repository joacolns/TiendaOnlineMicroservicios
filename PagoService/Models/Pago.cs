using System.ComponentModel.DataAnnotations;

namespace PagoService.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public string Metodo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
