using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPedidos.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="O usuário e obrigatório")]
        [StringLength(45,ErrorMessage ="O nome do usuário deve ter no mínimo 4 caracteres e no máximo 56",MinimumLength = 4)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O nome do usuário e obrigatório")]
        [StringLength(60,ErrorMessage ="O nome completo não pode passar de 60 caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um dígito e um caractere especial.")]
        [StringLength(20,ErrorMessage = "A senha não pode passar 20 caracteres e o mínimo e 6",MinimumLength = 6)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Senha", ErrorMessage = "As senhas não correspondem.")]
        public string ConfimarSenha { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
