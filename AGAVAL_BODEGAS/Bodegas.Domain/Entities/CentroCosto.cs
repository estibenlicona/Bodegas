using Bodegas.Domain.Attributes;

namespace Bodegas.Domain.Entities
{
    public class CentroCosto : BaseEntity
    {
        public string Codigo { get; set; } = default!;
        [Upgradeable]
        public string nom_cco { get; set; } = default!;
    }
}
