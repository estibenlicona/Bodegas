using Bodegas.Domain.Attributes;

namespace Bodegas.Domain.Entities
{
    public class Bodega : BaseEntity
    {
        [Upgradeable]
        public string Nombre { get; set; } = default!;
        [Upgradeable]
        public string Direccion { get; set; } = default!;
        [Upgradeable]
        public string Telefono { get; set; } = default!;
        [Upgradeable]
        public int? ValidaReferencias { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        public string CodigoSucursal { get; set; } = default!;
        public string CodigoCentroCosto { get; set; } = default!;
        public string CodigoTercero { get; set; } = default!;
        public string CodigoCiudad { get; set; } = default!;
        public string Formato { get; set; } = default!;
        public string? cod_claptv { get; set; } = default!;
        public string? cuenta_banco { get; set; } = default!;
        public string? resp_bod { get; set; } = default!;
        public string? cod_cl1 { get; set; } = default!;
        public string? cod_cl2 { get; set; } = default!;
        public string? cod_cl3 { get; set; } = default!;
        public int? ind_tras { get; set; } = default!;
        public DateTime? fec_min { get; set; } = default!;
        public int? ind_distr { get; set; } = default!;
        public int? ind_pagare { get; set; } = default!;
        public int? ind_ped_entretiendas { get; set; } = default!;
        public int? ind_ped_tiendavirtual { get; set; } = default!;
        public bool? ind_huella_sup { get; set; } = default!;
        public short? IndSmsAbonos { get; set; } = default!;
        public int? ind_sms_nps { get; set; } = default!;
        public int? val_sms_nps { get; set; } = default!;

        //Defecto
        public string? ind_bodven { get; set; }
        public string? ind_ter { get; set; }
        public string? prefijo { get; set; }
        public string? car_num { get; set; }
        public decimal? val_dia { get; set; }
        public short? ind_gar { get; set; }
        public decimal? lon_num { get; set; }
        public decimal? num_act { get; set; }
        public short? ind_firma_elec { get; set; }
        public short? ind_aum_cupo { get; set; }
        public short? ind_refreq { get; set; }
        public byte? mod_firma_elec { get; set; }
        public virtual Caja Caja { get; set; } = default!;
        public virtual Resolucion Resolucion { get; set; } = default!;
        public virtual BodegaAliado BodegaAliado { get; set; } = default!;
        public virtual Sucursal Sucursal { get; set; } = default!;

        public Bodega()
        {
            prefijo = "Z";
            ind_gar = 0;
            car_num = "TAE";
            lon_num = 8;
            ind_bodven = "1";
            ind_ter = "1";
            val_dia = 0;
            ind_firma_elec = 1;
            ind_aum_cupo  = 1;
            ind_refreq = 1;
            mod_firma_elec = 2;
            ValidaReferencias = 0;
            num_act = 0;
        }
    }
}
