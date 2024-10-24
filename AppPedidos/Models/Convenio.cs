using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Convenio
    {
        [Key]
        public int ConvenioId { get; set; }

        [StringLength(45,ErrorMessage ="O nome do convênio não pode passar de 45 caracteres")]
        [Required(ErrorMessage ="Informe o Nome do convênio")]
        public string NomeConvenio { get; set; }

        public bool Habilitado { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
