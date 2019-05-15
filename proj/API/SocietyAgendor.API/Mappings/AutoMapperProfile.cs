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
        }
    }
}