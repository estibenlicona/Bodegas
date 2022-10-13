using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bodegas.Domain.Entities
{
    public class Sucursal : BaseEntity
    {
        public string Codigo { get; set; } = default!;
        public string? Nombre { get; set; } = default!;
        [JsonIgnore]
        [IgnoreDataMember] 
        public virtual ICollection<Bodega> Bodegas { get; set; } = default!;
    }
}
