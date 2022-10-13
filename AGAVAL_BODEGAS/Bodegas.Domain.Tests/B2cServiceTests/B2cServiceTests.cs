using Bodegas.Domain.Entities;
using Bodegas.Domain.Enums;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;

namespace Bodegas.Domain.Tests.B2cServiceTests
{
    [TestClass]
    public class B2cServiceTests
    {
        IB2CRepository _b2cRepository = default!;
        Services.B2CService _b2cService = default!;

        [TestInitialize]
        public void Init()
        {
            _b2cRepository = Substitute.For<IB2CRepository>();
            _b2cService = new(_b2cRepository);
        }

        [TestMethod]
        public async Task RegistrarSolicitud_Success()
        {
            GrupoB2C Grupo = new("CP1", "BODEGA PRUEBAS", "001", "Mega Center", 3, true, EnumTipoCupo.PLUS);

            _b2cRepository.PostAsync(Arg.Any<GrupoB2C>()).Returns(new ApiAliadosResponse("El centro de costos fue registrado correctamente en Azure B2C."));
            await _b2cService.RegistrarSolicitud(Grupo);

            await _b2cRepository.Received(1).PostAsync(Arg.Is(Grupo));

        }
    }
}
