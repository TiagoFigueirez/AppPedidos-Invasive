using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class SubcategoriaProduto
    {
        [Key]
        public int SubcategoriaId { get; set; }

        [Required(ErrorMessage = "O nome da Subcategoria é obrigatório")]
        [StringLength(45,ErrorMessage = "A subcategoria não pode passar de 45 caracteres")]
        public string NomeSubcategoria { get; set; }

        [ForeignKey("CategoriaProduto")]
        public int CategoriaId { get; set; }
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
