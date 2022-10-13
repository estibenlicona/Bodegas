using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class TerceroConfig : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.ToTable("gen_terceros");
            builder.HasKey(x => x.Identificacion);
            builder.Property(x => x.Identificacion).HasColumnName("ter_nit");
            builder.Property(x => x.Nombre).HasColumnName("ter_nombre");
        }
    }
}
