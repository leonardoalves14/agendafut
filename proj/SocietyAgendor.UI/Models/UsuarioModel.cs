using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class UsuarioModel
    {
        [Display(Name = "Id")]
        public int? Usuario_Id { get; set; }

        [Required]
        [Display(Name = "Login")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Usuario_Login { get; set; }

        [Display(Name = "Senha")]
        [StringLength(50, ErrorMessage = "É permitido até 50 caracteres.")]
        public string Usuario_Senha { get; set; }
    }
}
