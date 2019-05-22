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
    public class HorarioService : IHorarioService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://socityagendorservice.azurewebsites.net/api/horarios";

        public async Task<List<HorarioModel>> GetHorariosAsync()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var horarios = new List<HorarioModel>();

            var resposta = await client.GetAsync(URL).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<HorarioModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return horarios;
        }
        public async Task<List<HorariosDisponivelModel>> GetHorariosDisponiveisAsync(DateTime dia)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var horarios = new List<HorariosDisponivelModel>();
            string urlFinal = $"{URL}/disponiveis/{dia.ToString("yyyy-MM-dd")}";

            var resposta = await client.GetAsync(urlFinal).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<HorariosDisponivelModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return horarios;
        }

        public async Task<HorarioModel> CreateHorarioAsync(HorarioModel model)
        {
            var horario = new HorarioModel();

            HttpResponseMessage response = await client.PostAsync(
                URL,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var respostaStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<HorarioModel>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return horario;
        }

        public async Task<HttpStatusCode> UpdateHorarioAsync(HorarioModel model)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{URL}/{model.DiaSemana_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteHorarioAsync(HorarioModel model)
        {
            HttpResponseMessage response = await client.PostAsync(
                $"{URL}/delete/{model.Horario_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
