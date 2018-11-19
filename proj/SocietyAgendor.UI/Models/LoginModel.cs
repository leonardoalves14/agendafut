using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class LoginModel
    {
        [Required( ErrorMessage = "Campo usuário não pode ficar nulo.")]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required(ErrorMessage = "Campo senha não pode ficar nulo.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
