using SocietyAgendor.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyAgendor.API.Services
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioByUsuarioId(int usuarioId);
        Funcionario CreateFuncionario(Funcionario model);
        void UpdateFuncionario(Funcionario model);
        void DeleteFuncionario(int funcionarioId);
        bool FuncionarioExists(int funcionarioId);
    }
}
