using Bodegas.Domain.DTOs;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Xunit;

namespace Bodegas.Api.Tests
{
    public class SucursalControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public SucursalControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task ListPage0Size10()
        {
            //Act
            var response = await _client.GetAsync($"api/Sucursal");
            string json = await response.Content.ReadAsStringAsync();
            List<SucursalDto>? sucursales = JsonConvert.DeserializeObject<List<SucursalDto>>(json);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(10, sucursales?.Count);
        }

        [Fact]
        public async Task ListPage1Size5()
        {
            //Arrange
            int page = 1;
            int size = 5;

            //Act
            var response = await _client.GetAsync($"api/Sucursal?page={page}&size={size}");
            string json = await response.Content.ReadAsStringAsync();
            List<SucursalDto>? sucursales = JsonConvert.DeserializeObject<List<SucursalDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(5, sucursales?.Count);
        }

        [Fact]
        public async Task ListPage0Size13()
        {
            //Arrange
            int page = 0;
            int size = 13;

            //Act
            var response = await _client.GetAsync($"api/Sucursal?page={page}&size={size}");
            string json = await response.Content.ReadAsStringAsync();
            List<SucursalDto>? sucursales = JsonConvert.DeserializeObject<List<SucursalDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(13, sucursales?.Count);
        }

        [Fact]
        public async Task ListFilterCodigo()
        {
            //Arrange
            string codigo = "003";

            //Act
            var response = await _client.GetAsync($"api/Sucursal?text={codigo}");
            string json = await response.Content.ReadAsStringAsync();
            List<SucursalDto>? sucursales = JsonConvert.DeserializeObject<List<SucursalDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(sucursales?.Count >= 1);
            Trace.Assert(sucursales?.Find(x => x.Codigo.Equals(codigo)) != null);
        }
        
        [Fact]
        public async Task ListFilterNombreNoResults()
        {
            //Arrange
            string nombre = "ETSCDFDF";

            //Act
            var response = await _client.GetAsync($"api/Sucursal?text={nombre}");
            string json = await response.Content.ReadAsStringAsync();
            List<SucursalDto>? sucursales = JsonConvert.DeserializeObject<List<SucursalDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(sucursales?.Count == 0);
        }

    }
}
