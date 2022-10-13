using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface ISucursalService
    {
        Task<List<Sucursal>> List(FilterArguments<Sucursal> args);
    }
}
