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
    public class AgendamentoService : IAgendamentoService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://socityagendorservice.azurewebsites.net/api/agendamentos";

        public async Task<List<AgendamentoModel>> GetAgendamentosAsync()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var agendamentos = new List<AgendamentoModel>();

            var resposta = await client.GetAsync(URL).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<AgendamentoModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return agendamentos;
        }

        public async Task<AgendamentoModel> CreateAgendamentoAsync(AgendamentoModel model)
        {
            var agendamento = new AgendamentoModel();

            HttpResponseMessage response = await client.PostAsync(
                URL,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var respostaStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<AgendamentoModel>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return agendamento;
        }

        public async Task<HttpStatusCode> UpdateAgendamentoAsync(AgendamentoModel model)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{URL}/{model.Agendamento_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAgendamentoAsync(int agendamentoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{URL}/{agendamentoId}");

            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    }
}