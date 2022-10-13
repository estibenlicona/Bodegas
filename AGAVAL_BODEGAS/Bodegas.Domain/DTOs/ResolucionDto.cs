namespace Bodegas.Domain.DTOs
{
    public class ResolucionDto
    {
        public string NumeroResolucion { get; set; } = default!;
        public DateTime? Fecha { get; set; } = default!;
        public string ResolucionInicial { get; set; } = default!;
        public string ResolucionFinal { get; set; } = default!;
        public string CodigoAplicacion { get; set; } = default!;
        public string Caja { get; set; } = default!;
        public string CodigoContable { get; set; } = default!;
        public string Prefijo { get; set; } = default!;
    }
}
