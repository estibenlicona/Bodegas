namespace Bodegas.Domain.Entities
{
    public class Tercero : BaseEntity
    {
        public string Identificacion { get; set; } = default!;
        public string Nombre { get; set; } = default!;
    }
}
