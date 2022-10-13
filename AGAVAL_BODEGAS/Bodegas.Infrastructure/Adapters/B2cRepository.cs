using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using Bodegas.Infrastructure.Config;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Bodegas.Infrastructure.Adapters
{
    public class B2CRepository : IB2CRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApiAliadosConfig _apiAliadosConfig;
        private readonly string ERROR = "Ha ocurrido un error creando el centro de costos en Azure B2C.\nComunicate con el area de soporte.";

        public B2CRepository(HttpClient httpClient, ApiAliadosConfig apiAliadosConfig)
        {
            _httpClient = httpClient;
            _apiAliadosConfig = apiAliadosConfig;
        }

        public async Task<ApiAliadosResponse> PostAsync(GrupoB2C grupo)
        {
            string json = JsonConvert.SerializeObject(grupo);
            StringContent data = new(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add(_apiAliadosConfig.HeaderName, _apiAliadosConfig.HeaderValue);
            HttpResponseMessage response = await _httpClient.PostAsync("centrocostos/crearcentrocostos", data);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest) throw new Exception(ERROR);
            ApiAliadosResponse? apiAliadosResponse = JsonConvert.DeserializeObject<ApiAliadosResponse>(result);
            return apiAliadosResponse ?? throw new Exception(ERROR);
        }
    }
}
