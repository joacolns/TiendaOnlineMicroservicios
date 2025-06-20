using System.ComponentModel.DataAnnotations;

namespace PedidosService.Models
{
    public class Pedido
    {

        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Estado { get; set; }
        
    }
}
