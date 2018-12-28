using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class CargoModel
    {
        public int? Cargo_Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "É permitido até 255 caracteres.")]
        public string Cargo_Desc { get; set; }
    }
}
