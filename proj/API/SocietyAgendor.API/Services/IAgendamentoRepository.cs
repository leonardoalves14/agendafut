using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IAgendamentoRepository
    {
        List<Agendamento> GetAllAgendamentos();
        int CreateAgendamento(Agendamento model);
        void UpdateAgendamento(Agendamento model);
        void DeleteAgendamento(int agendamentoId);
    }
}
