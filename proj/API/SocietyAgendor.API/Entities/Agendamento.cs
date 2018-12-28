using System;

namespace SocietyAgendor.API.Entities
{
    public class Agendamento
    {
        public int? AgendamentoId { get; set; }
        public string AgendamentoDescricao { get; set; }        
        public DateTime DataAgendamento { get; set; }
        public int DiaSemanaId { get; set; }
        public string DiaSemanaDesc { get; set; }
        public int HorarioId { get; set; }
        public string HorarioDesc { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int EstabelecimentoId { get; set; }
        public string EstabelecimentoNome { get; set; }
    }
}
