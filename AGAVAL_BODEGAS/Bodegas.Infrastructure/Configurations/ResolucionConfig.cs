using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class ResolucionConfig : IEntityTypeConfiguration<Resolucion>
    {
        public void Configure(EntityTypeBuilder<Resolucion> builder)
        {
            builder.ToTable("gen_consecsuc");
            builder.HasKey(x => new { x.cod_apl, x.CodigoCaja, x.cod_con });
            builder.Property(x => x.CodigoCaja).HasColumnName("cod_suc");
        }
    }
}
