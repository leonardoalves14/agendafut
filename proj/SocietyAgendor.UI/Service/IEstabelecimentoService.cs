using SocietyAgendor.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Service
{
    public interface IEstabelecimentoService
    {
        Task<List<EstabelecimentoModel>> GetEstabelecimentoAsync();
        Task<EstabelecimentoModel> CreateEstabelecimentoAsync(EstabelecimentoModel model);
        Task<HttpStatusCode> UpdateEstabelecimentoAsync(EstabelecimentoModel model);
        Task<HttpStatusCode> DeleteEstabelecimentoAsync(int usuarioId);
        Task<dynamic> GetEstabelecimentosAsync();
    }
}
