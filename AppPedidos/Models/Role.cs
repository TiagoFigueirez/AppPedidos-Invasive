using System.ComponentModel.DataAnnotations;

namespace AppPedidos.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "O nome do grupo e obrigatório")]
        [StringLength(45,ErrorMessage = "O nome do grupo não pode passar de 45 caracteres")]
        public string NameRole { get; set; }

        public List<Usuario> Usuarios { get; set; } 
        public List<Convenio> Convenios { get; set; }
        public List<Medico> Medicos { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public List<EmailEnvioModel> EmailEnvio { get; set; }
    }
}
