using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface ICajaServices
    {
        Task<List<Caja>> List(FilterArguments<Caja> arguments);

        Task<Caja> Get(string cod_caj);

        Task AddAsync(Caja caja);

        Task UpdateAsync(Caja caja);
    }
}
