using SocietyAgendor.UI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IHorarioService
    {
        Task<List<HorarioModel>> GetHorariosAsync();
        Task<HorarioModel> CreateHorarioAsync(HorarioModel model);
        Task<HttpStatusCode> UpdateHorarioAsync(HorarioModel model);
        Task<HttpStatusCode> DeleteHorarioAsync(HorarioModel model);
        Task<List<HorariosDisponivelModel>> GetHorariosDisponiveisAsync(DateTime dia);
    }
}
