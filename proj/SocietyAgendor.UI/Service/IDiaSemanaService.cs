using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IDiaSemanaService
    {
        Task<List<DiaDaSemanaModel>> GetDiasDaSemanaAsync();
    }
}
