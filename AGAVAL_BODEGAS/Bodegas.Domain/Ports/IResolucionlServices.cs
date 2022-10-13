using Bodegas.Domain.Entities;

namespace Bodegas.Domain.Ports
{
    public interface IResolucionlServices
    {
        Task<Resolucion> Get(string CodigoCaja);
        Task AddAsync(Resolucion Resolucion);
        Task UpdateAsync(Resolucion Resolucion);
    }
}
