using AutoMapper;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;

namespace SocietyAgendor.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Funcionario, FuncionarioModel>().ReverseMap();
            CreateMap<Funcionario, PerfilFuncionarioModel>();
            CreateMap<Agendamento, AgendamentoModel>().ReverseMap();
            CreateMap<Cargo, CargoModel>().ReverseMap();
            CreateMap<Horario, HorarioModel>().ReverseMap();
            CreateMap<HorarioDisponivel, HorarioDisponivelModel>().ReverseMap();
            CreateMap<Cliente, ClienteModel>().ReverseMap();
            CreateMap<DiaSemana, DiaSemanaModel>();
        }
    }
}