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
    public class CargoService : ICargoService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URL = "http://socityagendorservice.azurewebsites.net/api/cargos";

        public async Task<List<CargoModel>> GetCargosAsync()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var usuarios = new List<CargoModel>();

            var resposta = await client.GetAsync(URL).ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<CargoModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return usuarios;
        }

        public async Task<CargoModel> CreateHorarioAsync(CargoModel model)
        {
            var cargo = new CargoModel();

            HttpResponseMessage response = await client.PostAsync(
                URL,
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var respostaStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<CargoModel>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return cargo;
        }

        public async Task<HttpStatusCode> UpdateCargoAsync(CargoModel model)
        {
            HttpResponseMessage response = await client.PutAsync(
                $"{URL}/{model.Cargo_Id}",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteCargoAsync(int cargoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{URL}/{cargoId}");

            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    }
}
