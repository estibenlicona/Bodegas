using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface IBodegaServices
    {
        Task<Tuple<int, List<Bodega>>> ListAsync(FilterArguments<Bodega> arguments);

        Task<Bodega> GetAsync(string cod_bod);

        Task AddAsync(Bodega bodega);

        Task UpdateAsync(Bodega bodega);
    }
}
