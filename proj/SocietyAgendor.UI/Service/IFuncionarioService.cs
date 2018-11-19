using SocietyAgendor.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IFuncionarioService
    {
        Task<List<FuncionarioModel>> GetFuncionariosAsync();
        Task<FuncionarioModel> CreateFuncionarioAsync(FuncionarioModel model);
        Task<HttpStatusCode> UpdateFuncionarioAsync(FuncionarioModel model);
        Task<HttpStatusCode> DeleteFuncionarioAsync(int usuarioId);
    }
}
