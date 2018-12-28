using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> GetAllFuncionarios();
        Funcionario CreateFuncionario(Funcionario model);
        void UpdateFuncionario(Funcionario model);
        void DeleteFuncionario(int funcionarioId);
        bool FuncionarioExists(int funcionarioId);
    }
}
