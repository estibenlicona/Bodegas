using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using Bodegas.Domain.Services;
using Bodegas.Infrastructure.Helpers;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Bodegas.Domain.Tests.BodegaServiceTests
{
    [TestClass]
    public class CajaServiceTests
    {
        IGenericRepository<Caja> _cajaRepository = default!;
        CajaServices _cajaServices = default!;

        [TestInitialize]
        public void Init()
        {
            _cajaRepository = Substitute.For<IGenericRepository<Caja>>();
            _cajaServices = new(_cajaRepository);
        }

        [TestMethod]
        public async Task AddAsync()
        {
            Caja caja = Utilities.ReadJson<Caja>("SeedAddCajaTest") ?? new Caja();
            await _cajaServices.AddAsync(caja);
            await _cajaRepository.Received().AddAsync(Arg.Is(caja));
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            Caja caja = Utilities.ReadJson<Caja>("SeedAddCajaTest") ?? new Caja();
            await _cajaServices.UpdateAsync(caja);
            await _cajaRepository.Received().UpdateAsync(Arg.Is(caja));
        }

        [TestMethod]
        public async Task GetAsync()
        {

            Caja caja = Utilities.ReadJson<Caja>("SeedAddCajaTest") ?? new Caja();
            _cajaRepository.Get(Arg.Any<Expression<Func<Caja, bool>>>()).Returns(caja);

            Caja cajaResult = await _cajaServices.Get(caja.Codigo);
            await _cajaRepository.Received().Get(Arg.Any<Expression<Func<Caja, bool>>>());

            Assert.IsNotNull(cajaResult);
            Trace.Assert(cajaResult.Codigo == cajaResult.Codigo);
        }

        [TestMethod]
        public async Task ListAsync()
        {

            List<Caja> cajas = Utilities.ReadJson<List<Caja>>("SeedCajasTest") ?? new List<Caja>();
            _cajaRepository.List(Arg.Any<string>()).Returns(cajas.AsQueryable());

            FilterArguments<Caja> arguments = new(){ Page = 0, Size = 10 };
            List<Caja> response = await _cajaServices.List(arguments);

            Assert.IsNotNull(response);
            Trace.Assert(response.Count == cajas.Count);

        }
    }
}
