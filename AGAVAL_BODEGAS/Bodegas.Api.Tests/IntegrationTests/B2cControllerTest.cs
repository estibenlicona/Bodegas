using Bodegas.Applications.B2cService.Commands;
using Bodegas.Domain.Helpers;
using Bodegas.Infrastructure.Helpers;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WireMock.RequestBuilders;
using WireMock.Server;
using Xunit;

namespace Bodegas.Api.Tests
{
    public class B2cControllerTest
    {
        private readonly IntegrationTestBuilder _builder;
        private readonly HttpClient _client = default!;
        private readonly WireMockServer _wireMockServer;

        public B2cControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
            _wireMockServer = WireMockServer.Start(8086);
            _wireMockServer.Given(Request.Create().WithPath("/centrocostos/crearcentrocostos").UsingPost())
                .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).
                WithBodyAsJson(new {message="centro de costos creado correctamente"}));
        }

        [Fact]
        public async Task Post()
        {
            //Arrange
            B2CCommand? b2c = Utilities.ReadJson<B2CCommand>("SeedPostB2cTest");
            var postContent = new StringContent(JsonConvert.SerializeObject(b2c), Encoding.UTF8, "text/json");

            //Act
            var response = await _client.PostAsync($"api/b2c/registro", postContent);
            string json = await response.Content.ReadAsStringAsync();
            ApiResponse<bool>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(apiResponse?.Ok);
        }
    }
}
