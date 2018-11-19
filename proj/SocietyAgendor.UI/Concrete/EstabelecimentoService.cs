using Newtonsoft.Json;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Concrete
{
    public class EstabelecimentoService : IEstabelecimentoService
    {

        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://socityagendorservice.azurewebsites.net/api/estabelecimentos";

        public async Task<List<EstabelecimentoModel>> GetEstabelecimentoAsync()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var usuarios = new List<EstabelecimentoModel>();

            var resposta = await client.GetAsync(URL).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<EstabelecimentoModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return usuarios;
        }

        public async Task<EstabelecimentoModel> CreateEstabelecimentoAsync(EstabelecimentoModel model)
        {
            var estabelecimento = new EstabelecimentoModel();

            HttpResponseMessage response = await client.PostAsync(
                URL,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var respostaStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<EstabelecimentoModel>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return estabelecimento;
        }

        public async Task<HttpStatusCode> DeleteEstabelecimentoAsync(int estabelecimentoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{URL}/{estabelecimentoId}");

            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }      

        public async Task<HttpStatusCode> UpdateEstabelecimentoAsync(EstabelecimentoModel model)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{URL}/{model.Estabelecimento_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public Task<dynamic> GetEstabelecimentosAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}