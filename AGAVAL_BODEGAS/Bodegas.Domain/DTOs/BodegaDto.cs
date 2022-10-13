namespace Bodegas.Domain.DTOs
{
    public class BodegaDto
    {
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Direccion { get; set; } = default!;
        public string Telefono { get; set; } = default!;
        public string CentroCosto { get; set; } = default!;
        public string Nit { get; set; } = default!;
        public string CodigoCiudad { get; set; } = default!;
        public string? CodigoSucursal { get; set; } = default!;
        public string? NombreSucursal { get; set; } = default!;
        public int? ValidaReferencias { get; set; } = default!;
        public string? Formato { get; set; } = default!;

        public virtual CajaDto CajaDto { get; set; } = default!;
        public virtual ResolucionDto ResolucionDto { get; set; } = default!;
        public virtual BodegaAliadoDto InformacionAliadoDto { get; set; } = default!;
        public virtual SucursalDto? SucursalDto { get; set; } = default!;

    }
}
