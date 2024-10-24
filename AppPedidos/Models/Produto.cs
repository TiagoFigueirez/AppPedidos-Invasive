using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O Código do produto é obrigtório")]
        [StringLength(45,ErrorMessage ="O manho máximo do código do produto não pode passar de 45 caracteres")]
        public string CodigoProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigtório")]
        [StringLength(80, ErrorMessage = "O manho máximo da descrição do produto não pode passar de 45 caracteres")]
        public string DescricaoProduto { get; set; }

        [ForeignKey("SubcategoriaProduto")]
        public int SubcategoriaId { get; set; }
        public SubcategoriaProduto SubcategoriaProduto { get; set; }
        public  IEnumerable<PedidosItens> PedidosItens { get; set; }

    }
}
