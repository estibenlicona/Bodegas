using AutoMapper;
using Bodegas.Domain.DTOs;
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
    public class BodegaServiceTests
    {
        IGenericRepository<Bodega> _bodegaRepository = default!;
        IGenericRepository<BodegaAliado> _bodegaAliadoRepository = default!;
        IGenericRepository<Caja> _cajaRepository = default!;
        IGenericRepository<Resolucion> _resolucionRepository = default!;
        IGenericRepository<CentroCosto> _centroCostoRepository = default!;

        BodegaServices _bodegaServices = default!;

        [TestInitialize]
        public void Init()
        {
            _bodegaRepository = Substitute.For<IGenericRepository<Bodega>>();
            _bodegaAliadoRepository = Substitute.For<IGenericRepository<BodegaAliado>>();
            _cajaRepository = Substitute.For<IGenericRepository<Caja>>();
            _resolucionRepository = Substitute.For<IGenericRepository<Resolucion>>();
            _centroCostoRepository = Substitute.For<IGenericRepository<CentroCosto>>();
            _bodegaServices = new(
                _bodegaRepository,
                _bodegaAliadoRepository,
                _cajaRepository,
                _resolucionRepository,
                _centroCostoRepository
            );
        }

        [TestMethod]
        public async Task AddAsync()
        {

            Bodega bodega = Utilities.ReadJson<Bodega>("SeedPostBodegaEntityTest") ?? new Bodega();
            await _bodegaServices.AddAsync(bodega);

            await _bodegaRepository.Received().AddAsync(Arg.Is(bodega));
        }

        [TestMethod]
        public async Task UpdateAsync()
        {

            Bodega bodega = Utilities.ReadJson<Bodega>("SeedPostBodegaEntityTest") ?? new Bodega();
            await _bodegaServices.UpdateAsync(bodega);

            await _bodegaRepository.Received().UpdateAsync(Arg.Is(bodega));
        }
        [TestMethod]
        public async Task GetAsync()
        {

            Bodega bodega = Utilities.ReadJson<Bodega>("SeedPostBodegaEntityTest") ?? new Bodega();
            _bodegaRepository.Get(Arg.Any<Expression<Func<Bodega, bool>>>(), Arg.Any<string>()).Returns(bodega);
            Bodega bodegaResult = await _bodegaServices.GetAsync(bodega.Codigo);

            await _bodegaRepository.Received(1).Get(Arg.Any<Expression<Func<Bodega, bool>>>(), Arg.Any<string>());
            Assert.IsNotNull(bodegaResult);
            Trace.Assert(bodegaResult.Codigo == bodega.Codigo);
        }
        [TestMethod]
        public async Task ListAsync()
        {

            List<Bodega> bodegas = Utilities.ReadJson<List<Bodega>>("SeedBodegasTest") ?? new List<Bodega>();
            _bodegaRepository.List(Arg.Any<string>()).Returns(bodegas.AsQueryable());

            FilterArguments<Bodega> arguments = new(){ Page = 0, Size = 10 };
            Tuple<int, List<Bodega>> response = await _bodegaServices.ListAsync(arguments);

            string includes = "Sucursal,BodegaAliado";
            _bodegaRepository.Received(1).List(Arg.Is(includes));

            Assert.IsNotNull(response);
            Trace.Assert(response.Item1 == 256);
            Trace.Assert(response.Item2.Count == 10);

            await Task.CompletedTask;

        }
    }
}
