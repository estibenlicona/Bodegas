using Bodegas.Domain.Attributes;

namespace Bodegas.Domain.Entities
{
    public class BodegaAliado : BaseEntity
    {
        public string Codigo { get; set; } = default!;
        [Upgradeable]
        public bool? RecibeAbonoAgaval { get; set; }
        [Upgradeable]
        public bool? RecibeAbonoTienda { get; set; }
        [Upgradeable]
        public bool? RecibeAbonoComercio { get; set; }
        [Upgradeable]
        public string e_mail_cnt { get; set; } = default!;
        [Upgradeable]
        public decimal? por_comision { get; set; } = default!;
        [Upgradeable]
        public string? sector { get; set; } = default!;
        [Upgradeable]
        public string? repre_legal { get; set; } = default!;
        [Upgradeable]
        public DateTime? ini_fact { get; set; } = default!;
        [Upgradeable]
        public int? d_pagos { get; set; } = default!;
        [Upgradeable]
        public bool? activo { get; set; } = default!;
        [Upgradeable]
        public int? rec_abo_aga { get; set; } = default!;
        [Upgradeable]
        public string? CodigoCentroCosto { get; set; } = default!;
        public int? ind_ref { get; set; } = default!;
        public DateTime? f_activacion { get; set; } = default!;
        [Upgradeable]
        public DateTime? f_inactivacion { get; set; } = default!;
        [Upgradeable]
        public string? t_cupo { get; set; } = default!;
        public virtual Bodega Bodega { get; set; } = default!;
    }
}
