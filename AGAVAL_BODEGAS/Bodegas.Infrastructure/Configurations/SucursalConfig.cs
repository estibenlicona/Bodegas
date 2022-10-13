using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class SucursalConfig : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.ToTable("gen_sucursal");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("cod_suc");
            builder.Property(x => x.Nombre).HasColumnName("nom_suc");
        }
    }
}
