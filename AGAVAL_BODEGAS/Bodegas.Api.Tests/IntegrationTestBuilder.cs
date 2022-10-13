using Bodegas.Domain.Entities;
using Bodegas.Infrastructure.Context;
using Bodegas.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
namespace Bodegas.Api.Tests;
internal class IntegrationTestBuilder : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {

        var rootDb = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PrivadaDbContext>));
            services.AddDbContext<PrivadaDbContext>(options => {
                options.UseInMemoryDatabase("Testing", rootDb);
            });
        });
        
        SeedDatabase(builder.Build().Services);

        return base.CreateHost(builder);

    }

    void SeedDatabase(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<PrivadaDbContext>();
            if(!db.Set<Sucursal>().Any()) db.Set<Sucursal>().AddRange(Utilities.GetSeedSucursales());
            if(!db.Set<CentroCosto>().Any())db.Set<CentroCosto>().AddRange(Utilities.GetSeedCentrosCostos());
            if (!db.Set<Bodega>().Any()) db.Set<Bodega>().AddRange(Utilities.GetSeedBodegas());
            if (!db.Set<BodegaAliado>().Any()) db.Set<BodegaAliado>().AddRange(Utilities.GetSeedBodegasAliados());
            if (!db.Set<Tercero>().Any()) db.Set<Tercero>().AddRange(Utilities.GetSeedTerceros());
            if (!db.Set<Caja>().Any()) db.Set<Caja>().AddRange(Utilities.GetSeedCajas());
            if (!db.Set<Resolucion>().Any()) db.Set<Resolucion>().AddRange(Utilities.GetSeedResoluciones());
            db.SaveChanges();
        }
    }
}