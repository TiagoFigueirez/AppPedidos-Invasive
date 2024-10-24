using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class PedidosItens
    {
        [Key]
        public int PedidosItensId { get; set; }
        [Required]
        [ForeignKey("Produto")]
        public int ProdutosId { get; set; }
        [Required]
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        [Required(ErrorMessage = "A quantidade não pode ser menor que um")]
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public Pedido Pedido { get; set; }

    }
}
