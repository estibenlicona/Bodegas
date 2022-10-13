namespace Bodegas.Domain.DTOs
{
    public class CajaDto
    {
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Bodega { get; set; } = default!;
        public string CentroCosto { get; set; } = default!;
        public string Prefijo { get; set; } = default!;
    }
}
