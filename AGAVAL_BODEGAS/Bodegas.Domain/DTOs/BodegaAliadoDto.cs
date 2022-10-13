namespace Bodegas.Domain.DTOs
{
    public class BodegaAliadoDto
    {
        public string CodigoBodega { get; set; } = default!;
        public string EmailContable { get; set; } = default!;
        public string Sector { get; set; } = default!;
        public string RepresentanteLegal { get; set; } = default!;
        public DateTime? InicioFacturacion { get; set; } = default!;
        public int? DiasPago { get; set; } = default!;
        public bool? Activo { get; set; } = default!;
        public DateTime? FechaActivacion { get; set; } = default!;
        public DateTime? FechaInActivacion { get; set; } = default!;
        public int? RecibeAbonos { get; set; } = default!;
        public int? IndicadorReferidos { get; set; } = default!;
        public decimal? PorcentjeComision { get; set; } = default!;
        public string TipoCupo { get; set; } = default!;
        public bool? RecibeAbonoAgaval { get; set; }
        public bool? RecibeAbonoTienda { get; set; }
        public bool? RecibeAbonoComercio { get; set; }
    }
}
