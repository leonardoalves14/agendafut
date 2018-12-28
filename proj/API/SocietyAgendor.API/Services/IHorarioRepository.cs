using SocietyAgendor.API.Entities;
using System;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IHorarioRepository
    {
        List<Horario> GetAllHorarios();
        List<HorarioDisponivel> GetHorariosDisponiveis(DateTime dia);
        Horario CreateHorario(Horario model);
        void UpdateHorario(Horario model);
        void DeleteHorario(int horarioId, int diaSemanaId);
    }
}
