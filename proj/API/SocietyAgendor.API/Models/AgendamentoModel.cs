using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.API.Models
{
    public class AgendamentoModel
    {
        public int? Agendamento_Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        public string Agendamento_Descricao { get; set; }

        public DateTime DataAgendamento { get; set; }

        public int DiaSemana_Id { get; set; }

        public string DiaSemana_Desc { get; set; }

        public int Horario_Id { get; set; }

        public string Horario_Desc { get; set; }

        public int Cliente_Id { get; set; }

        public string Cliente_Nome { get; set; }

        public int Estabelecimento_Id { get; set; }

        public string Estabelecimento_Nome { get; set; }
    }
}
