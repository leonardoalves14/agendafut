using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAllUsuarios();
        Usuario CreateUsuario(Usuario model);
        void UpdateUsuario(Usuario model);
        void DeleteUsuario(int usuarioId);
        void UpdateUsuarioSenha(Usuario model);
        bool LoginUsuario(Usuario model);
    }
}
