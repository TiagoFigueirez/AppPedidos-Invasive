using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime? DataProcedimento { get; set; }

        [Required(ErrorMessage = "informe o hospital")]
        public int HospitalId { get; set; }

        [Required(ErrorMessage = "informe o paciente")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "informe o convênio")]
        public int ConvenioId { get; set; }

        [Required(ErrorMessage = "informe o médico")]   
        public int MedicosId { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]  
        public  bool Emergencial { get; set; }

        [StringLength(200,ErrorMessage ="O máximo de observações e de 200 caracteres")]
        public string? Observações { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(MedicosId))]
        public Medico Medico { get; set; }

        [ForeignKey(nameof(HospitalId))]
        public Hospital Hospital { get; set; }

        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(ConvenioId))]
        public Convenio Convenio { get; set; }
        public Usuario Usuario { get; set; }
        public List<PedidosItens> PedidosItens { get; set; }
    }
}
