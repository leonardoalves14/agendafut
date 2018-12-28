using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IDiaSemanaRepository
    {
        List<DiaSemana> GetAllDiasDaSemana();
    }
}