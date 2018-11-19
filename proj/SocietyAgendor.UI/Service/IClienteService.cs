using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IClienteService
    {
        Task<List<ClienteModel>> GetClientesAsync();
        Task<ClienteModel> CreateClientesAsync(ClienteModel model);
        Task<HttpStatusCode> UpdateClientesAsync(ClienteModel model);
        Task<HttpStatusCode> DeleteClientesAsync(int clienteId);
    }
}
