using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class CargoModel
    {
        [Display(Name = "Id")]
        public int? Cargo_Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é requirido.")]
        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Cargo_Desc { get; set; }
    }
}
