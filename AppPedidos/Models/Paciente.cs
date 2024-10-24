using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        [StringLength(60, ErrorMessage = "O nome do paciente não pode passar de 60 caracteres")]
        [Required(ErrorMessage = "Informe o Nome do paciente")]
        public string NomePaciente { get; set; }

        public bool Habilitado { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public IEnumerable<Pedido> Pedido { get; set; }
    }
}
