using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API.Concrete
{
    public class DiaSemanaRepository : Base.Base, IDiaSemanaRepository
    {
        public DiaSemanaRepository(IConfiguration configuration) : base(configuration) { }

        public List<DiaSemana> GetAllDiasDaSemana()
        {
            return ExecuteSP<DiaSemana>("spsDiaSemana");
        }
    }
}