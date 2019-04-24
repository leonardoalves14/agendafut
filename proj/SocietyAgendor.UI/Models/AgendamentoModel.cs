using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyAgendor.UI.Models
{
    public class AgendamentoModel
    {
        public int? Agendamento_Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "É permitido até 200 caracteres.")]
        [Display(Name = "Descrição")]
        public string Agendamento_Descricao { get; set; }

        [Display(Name = "Data do agendamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAgendamento { get; set; }

        [Display(Name = "Id Dia da Semana")]
        public int DiaSemana_Id { get; set; }

        [Display(Name = "Dia da Semana")]
        public string DiaSemana_Desc { get; set; }

        [Display(Name = "Id do Horário")]
        public int Horario_Id { get; set; }

        [Display(Name = "Descrição do Horário")]
        public string Horario_Desc { get; set; }

        [Display(Name = "Id do Cliente")]
        public int Cliente_Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string Cliente_Nome { get; set; }

        [Display (Name = "Id do Estabelecimento")]
        public int Estabelecimento_Id { get; set; }

        [Display(Name = "Estabelecimento")]
        public string Estabelecimento_Nome { get; set; }
    }
}
