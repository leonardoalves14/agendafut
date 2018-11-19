using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetUsuariosAsync();
        Task<UsuarioModel> CreateUsuarioAsync(UsuarioModel model);
        Task<HttpStatusCode> UpdateUsuarioAsync(UsuarioModel model);
        Task<HttpStatusCode> DeleteUsuarioAsync(int usuarioId);
        Task<HttpStatusCode> LoginUsuarioAsync(UsuarioModel model);
        // TODO: UPDATE PASSWORD
    }
}
