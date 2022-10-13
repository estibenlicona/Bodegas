using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface ITerceroService
    {
        Task<List<Tercero>> List(FilterArguments<Tercero> args);
    }
}
