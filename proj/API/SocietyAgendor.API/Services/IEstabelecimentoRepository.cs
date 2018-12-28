using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IEstabelecimentoRepository
    {
        List<Estabelecimento> GetAllEstabelecimentos();
        Estabelecimento CreateEstabelecimento(Estabelecimento model);
        void UpdateEstabelecimento(Estabelecimento model);
        void DeleteEstabelecimento(int estabelecimentoId);
        bool EstabelecimentoExists(int estabelecimentoId);
    }
}
