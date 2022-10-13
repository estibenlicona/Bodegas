using Bodegas.Domain.Entities;
using Bodegas.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bodegas.Infrastructure.Context
{
    public class PrivadaDbContext : DbContext
    {
        public DbSet<Bodega> Bodega = default!;
        public DbSet<BodegaAliado> BodegaAliado = default!;
        public DbSet<Caja> Caja = default!;
        public DbSet<Resolucion> Resolucion = default!;
        public DbSet<Sucursal> Sucursal = default!;
        public DbSet<CentroCosto> CentroCosto = default!;
        public DbSet<Tercero> Tercero = default!;
        public PrivadaDbContext(DbContextOptions<PrivadaDbContext> options) : base(options)
        {

        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                return;
            }

            builder.ApplyConfiguration(new BodegaConfig());
            builder.ApplyConfiguration(new BodegaAliadoConfig());
            builder.ApplyConfiguration(new CajaConfig());
            builder.ApplyConfiguration(new ResolucionConfig());
            builder.ApplyConfiguration(new SucursalConfig());
            builder.ApplyConfiguration(new CentroCostoConfig());
            builder.ApplyConfiguration(new TerceroConfig());

            base.OnModelCreating(builder);
        }
    }
}
