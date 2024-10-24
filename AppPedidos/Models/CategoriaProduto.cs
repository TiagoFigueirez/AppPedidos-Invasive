using System.ComponentModel.DataAnnotations;

namespace AppPedidos.Models
{
    public class CategoriaProduto
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "O nome da Categoria e obrigatório")]
        [StringLength(45, ErrorMessage = "O nome da categoria não pode passar de 45 caracteres")]
        public string CategoriaNome { get; set; }

        public List<SubcategoriaProduto> Subcategorias { get; set; }
    }
}
