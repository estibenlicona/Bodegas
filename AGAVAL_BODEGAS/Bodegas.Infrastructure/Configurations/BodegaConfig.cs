using Bodegas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bodegas.Infrastructure.Configurations
{
    public class BodegaConfig : IEntityTypeConfiguration<Bodega>
    {
        public void Configure(EntityTypeBuilder<Bodega> builder)
        {
            builder.ToTable("inv_bodegas");
            builder.HasKey(e => e.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("cod_bod");
            builder.Property(x => x.CodigoCentroCosto).HasColumnName("cod_cco");
            builder.Property(x => x.CodigoSucursal).HasColumnName("cod_suc");
            builder.Property(x => x.CodigoTercero).HasColumnName("cod_ter");
            builder.Property(x => x.Nombre).HasColumnName("nom_bod");
            builder.Property(x => x.CodigoCiudad).HasColumnName("cod_ciu");
            builder.Property(x => x.Formato).HasColumnName("tipo_formato").HasDefaultValue("Aliado");
            builder.Property(x => x.Direccion).HasColumnName("dir_bod");
            builder.Property(x => x.Telefono).HasColumnName("tel_bod");
            builder.Property(x => x.ValidaReferencias).HasColumnName("ind_ref");

            builder.HasOne(x => x.Sucursal)
                .WithMany(i => i.Bodegas)
                .HasForeignKey(t => t.CodigoSucursal);

            builder.HasOne(x => x.BodegaAliado)
                .WithOne(i => i.Bodega)
                .HasForeignKey<BodegaAliado>(t => t.Codigo);

            builder.Ignore(x => x.Resolucion);
            builder.Ignore(x => x.Caja);

        }
    }
}
