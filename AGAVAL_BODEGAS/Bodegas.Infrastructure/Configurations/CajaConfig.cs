using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class CajaConfig : IEntityTypeConfiguration<Caja>
    {
        public void Configure(EntityTypeBuilder<Caja> builder)
        {
            builder.ToTable("gen_cajas");
            builder.HasKey(e => e.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("cod_caj");
            builder.Property(e => e.base_caj).HasColumnName("base");
        }
    }
}
