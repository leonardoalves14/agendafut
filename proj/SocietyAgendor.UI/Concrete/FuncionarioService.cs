using Newtonsoft.Json;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Concrete
{
    public class FuncionarioService : IFuncionarioService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://socityagendorservice.azurewebsites.net/api/funcionarios";

        public async Task<List<FuncionarioModel>> GetFuncionariosAsync()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var funcionarios = new List<FuncionarioModel>();

            var resposta = await client.GetAsync(URL).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<FuncionarioModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return funcionarios;
        }

        public async Task<FuncionarioModel> CreateFuncionarioAsync(FuncionarioModel model)
        {
            var funcionario = new FuncionarioModel();

            HttpResponseMessage response = await client.PostAsync(
                URL,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                using (var respostaStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<FuncionarioModel>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return funcionario;
        }

        public async Task<HttpStatusCode> UpdateFuncionarioAsync(FuncionarioModel model)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{URL}/{model.Funcionario_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            
                response.EnsureSuccessStatusCode();

                return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteFuncionarioAsync(int usuarioId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{URL}/{usuarioId}");

            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    }
}
