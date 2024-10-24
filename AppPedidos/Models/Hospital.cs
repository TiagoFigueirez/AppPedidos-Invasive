using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [StringLength(60, ErrorMessage = "O nome do hospital não pode passar de 60 caracteres")]
        [Required(ErrorMessage = "Informe o Nome do hospital")]
        public string NomeHospital { get; set; }

        public bool Habilitado { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Pedido> Pedido { get; set; }

    }
}
