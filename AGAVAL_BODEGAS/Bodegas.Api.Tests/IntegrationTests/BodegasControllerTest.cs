using Bodegas.Domain.DTOs;
using Bodegas.Domain.Helpers;
using Bodegas.Infrastructure.Helpers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;
using Xunit;

namespace Bodegas.Api.Tests
{
    public class BodegasControllerTest
    {
        private readonly IntegrationTestBuilder _builder;
        private readonly HttpClient _client = default!;

        public BodegasControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task ListPage0Size10()
        {
            //Act
            var response = await _client.GetAsync($"api/Bodegas");
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<List<BodegaDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<BodegaDto>>>(json);
            List<BodegaDto>? Bodegas = apiResponse?.Body;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(10, Bodegas?.Count);
        }

        [Fact]
        public async Task ListFilterCodigo()
        {
            //Arrange
            string column = "Codigo";
            string text = "C01";
            string filter = "Igual";

            //Act
            var response = await _client.GetAsync($"api/Bodegas?column={column}&filter={filter}&text={text}");
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<List<BodegaDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<BodegaDto>>>(json);
            List<BodegaDto>? Bodegas = apiResponse?.Body;
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(Bodegas?.Count >= 1);
            Trace.Assert(Bodegas?.Find(x => x.Codigo.Equals(text)) != null);
        }

        [Fact]
        public async Task ListFilterCodigoNoResults()
        {
            //Arrange
            string column = "Codigo";
            string text = "999";
            string filter = "Igual";

            //Act
            var response = await _client.GetAsync($"api/Bodegas?column={column}&filter={filter}&text={text}");
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<List<BodegaDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<BodegaDto>>>(json);
            List<BodegaDto>? Bodegas = apiResponse?.Body;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(Bodegas?.Count == 0);
        }

        

        

        [Fact]
        public async Task ListFilterDate()
        {
            //Arrange
            string filter = "Entre";
            string start = "2022-06-20";
            string end = "2022-06-24";
            string column = "BodegaAliado.f_activacion";


            //Act
            var response = await _client.GetAsync($"api/Bodegas?filter={filter}&column={column}&start={start}&end={end}");
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<List<BodegaDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<BodegaDto>>>(json);
            List<BodegaDto>? Bodegas = apiResponse?.Body;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(Bodegas?.Count == 3);
        }

        [Fact]
        public async Task Post()
        {
            //Arrange
            BodegaDto? bodega = Utilities.ReadJson<BodegaDto>("SeedPostBodegaTest2");
            var postContent = new StringContent(JsonConvert.SerializeObject(bodega), Encoding.UTF8, "text/json");

            //Act
            var response = await _client.PostAsync($"api/Bodegas", postContent);
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<bool>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(apiResponse?.Ok);
        }
        /*
        [Fact]
        public async Task Put()
        {
            
            //Arrange
            BodegaDto bodega = Utilities.ReadJson<BodegaDto>("SeedPutBodegaTest");
            var postContent = new StringContent(JsonConvert.SerializeObject(bodega), Encoding.UTF8, "text/json");

            //Act
            var response = await _client.PutAsync($"api/Bodegas", postContent);
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<bool>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(apiResponse?.Ok);
            
        }
        */

    }
}
