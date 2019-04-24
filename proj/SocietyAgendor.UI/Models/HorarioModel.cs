using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class HorarioModel
    {
        public int? Horario_Id { get; set; }

        [Required]
        [Display(Name = "De")]
        public TimeSpan Horario_De { get; set; }

        [Required]
        [Display(Name = "Até")]
        public TimeSpan Horario_Ate { get; set; }

        [Required]
        public int? DiaSemana_Id { get; set; }

        [Display(Name = "Dia da Semana")]
        public string DiaSemana_Desc { get; set; }
    }

    public class HorariosDisponivelModel
    {
        public int Horario_Id { get; set; }
        public string Horario_Desc { get; set; }
    }
}
