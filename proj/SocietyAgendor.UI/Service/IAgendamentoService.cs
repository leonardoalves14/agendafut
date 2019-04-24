using SocietyAgendor.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IAgendamentoService
    {
        Task<List<AgendamentoModel>> GetAgendamentosAsync();
        Task<AgendamentoModel> CreateAgendamentoAsync(AgendamentoModel model);
        Task<HttpStatusCode> UpdateAgendamentoAsync(AgendamentoModel model);
        Task<HttpStatusCode> DeleteAgendamentoAsync(int agendamentoId);
    }
}
