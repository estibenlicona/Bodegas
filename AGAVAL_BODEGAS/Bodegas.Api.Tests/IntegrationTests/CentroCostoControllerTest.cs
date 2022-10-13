using Bodegas.Domain.DTOs;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Xunit;

namespace Bodegas.Api.Tests
{
    public class CentroCostoControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public CentroCostoControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task ListPage1Size5()
        {
            //Arrange
            int page = 1;
            int size = 5;

            //Act
            var response = await _client.GetAsync($"api/CentroCosto?page={page}&size={size}");
            string json = await response.Content.ReadAsStringAsync();
            List<CentroCostoDto>? centrosCostos = JsonConvert.DeserializeObject<List<CentroCostoDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(5, centrosCostos?.Count);
        }

        [Fact]
        public async Task ListFilterCodigo()
        {
            //Arrange
            string codigo = "038";

            //Act
            var response = await _client.GetAsync($"api/CentroCosto?text={codigo}");
            string json = await response.Content.ReadAsStringAsync();
            List<CentroCostoDto>? centrosCostos = JsonConvert.DeserializeObject<List<CentroCostoDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(centrosCostos?.Count >= 1);
            Trace.Assert(centrosCostos?.Find(x => x.Codigo.Equals(codigo)) != null);
        }

        [Fact]
        public async Task ListFilterNombre()
        {
            //Arrange
            string nombre = "TIENDA VIRTUAL";

            //Act
            var response = await _client.GetAsync($"api/CentroCosto?text={nombre}");
            string json = await response.Content.ReadAsStringAsync();
            List<CentroCostoDto>? centrosCostos = JsonConvert.DeserializeObject<List<CentroCostoDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(centrosCostos?.Count >= 1);
            Trace.Assert(centrosCostos?.Find(x => x.Nombre.Equals(nombre)) != null);
        }

        [Fact]
        public async Task ListFilterNombreNoResults()
        {
            //Arrange
            string nombre = "ETSCDFDF";

            //Act
            var response = await _client.GetAsync($"api/CentroCosto?text={nombre}");
            string json = await response.Content.ReadAsStringAsync();
            List<CentroCostoDto>? centrosCostos = JsonConvert.DeserializeObject<List<CentroCostoDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(centrosCostos?.Count == 0);
        }

        [Fact]
        public async Task ListFilterCodigoNoResults()
        {
            //Arrange
            string codigo = "999";

            //Act
            var response = await _client.GetAsync($"api/CentroCosto?text={codigo}");
            string json = await response.Content.ReadAsStringAsync();
            List<CentroCostoDto>? centrosCostos = JsonConvert.DeserializeObject<List<CentroCostoDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(centrosCostos?.Count == 0);
        }
    }
}
