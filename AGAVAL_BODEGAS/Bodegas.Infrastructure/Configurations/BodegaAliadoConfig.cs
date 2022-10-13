using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class BodegaAliadoConfig : IEntityTypeConfiguration<BodegaAliado>
    {
        public void Configure(EntityTypeBuilder<BodegaAliado> builder)
        {
            builder.ToTable("inv_bodegas_aliados");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("cod_bod");
            builder.Property(x => x.RecibeAbonoAgaval).HasColumnName("recibe_abono_agaval");
            builder.Property(x => x.RecibeAbonoComercio).HasColumnName("recibe_abono_comercio");
            builder.Property(x => x.RecibeAbonoTienda).HasColumnName("recibe_abono_tienda");
            builder.Property(x => x.CodigoCentroCosto).HasColumnName("cod_cco");
        }
    }
}
