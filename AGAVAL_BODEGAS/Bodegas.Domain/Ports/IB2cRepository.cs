using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface IB2CRepository
    {
        Task<ApiAliadosResponse> PostAsync(GrupoB2C grupo);
    }
}
