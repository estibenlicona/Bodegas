using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class CentroCostoConfig : IEntityTypeConfiguration<CentroCosto>
    {
        public void Configure(EntityTypeBuilder<CentroCosto> builder)
        {
            builder.ToTable("gen_ccosto");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("cod_cco");
        }
    }
}
