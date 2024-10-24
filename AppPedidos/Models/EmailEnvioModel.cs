using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class EmailEnvioModel
    {
        [Key]
        public int EmailEnvioId { get; set; }

        [Required(ErrorMessage = "O informe o nome")]
        [StringLength(60, ErrorMessage = "O nome não pode passar de 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O informe o setor")]
        [StringLength(45, ErrorMessage = "O nome do setor não pode passar de 45 caracteres")]
        public string Setor { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
