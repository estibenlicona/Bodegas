using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface ICentroCostoService
    {
        Task<List<CentroCosto>> List(FilterArguments<CentroCosto> args);
    }
}
