using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }

        [StringLength(45, ErrorMessage = "O nome do médico não pode passar de 45 caracteres")]
        [Required(ErrorMessage = "Informe o Nome do medico")]
        public string NomeMedico { get; set; }

        public bool Habilitado { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Pedido> Pedido { get; set; }
    }
}
