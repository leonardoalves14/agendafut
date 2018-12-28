using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class HorarioModel
    {
        public int? Horario_Id { get; set; }

        [Required]
        public TimeSpan Horario_De { get; set; }

        [Required]
        public TimeSpan Horario_Ate { get; set; }

        [Required]
        public int? DiaSemana_Id { get; set; }

        public string DiaSemana_Desc { get; set; }
    }
}
