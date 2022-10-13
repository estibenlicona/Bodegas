using Bodegas.Domain.DTOs;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Xunit;

namespace Bodegas.Api.Tests
{
    public class TerceroControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public TerceroControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task ListPage0Size10()
        {
            //Act
            var response = await _client.GetAsync($"api/Tercero");
            string json = await response.Content.ReadAsStringAsync();
            List<TerceroDto>? terceros = JsonConvert.DeserializeObject<List<TerceroDto>>(json);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(10, terceros?.Count);
        }

        [Fact]
        public async Task ListPage1Size5()
        {
            //Arrange
            int page = 0;
            int size = 5;

            //Act
            var response = await _client.GetAsync($"api/Tercero?page={page}&limit={size}");
            string json = await response.Content.ReadAsStringAsync();
            List<TerceroDto>? terceros = JsonConvert.DeserializeObject<List<TerceroDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(5, terceros?.Count);
        }

        [Fact]
        public async Task ListFilterNit()
        {
            //Arrange
            string nit = "1028030384";

            //Act
            var response = await _client.GetAsync($"api/Tercero?nit={nit}");
            string json = await response.Content.ReadAsStringAsync();
            List<TerceroDto>? terceros = JsonConvert.DeserializeObject<List<TerceroDto>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Trace.Assert(terceros?.Count >= 1);
            Trace.Assert(terceros?.Find(x => x.Nit.Equals(nit)) != null);
        }

    }
}
