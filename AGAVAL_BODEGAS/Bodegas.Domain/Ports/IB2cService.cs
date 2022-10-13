using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;

namespace Bodegas.Domain.Ports
{
    public interface IB2CService
    {
        Task<ApiAliadosResponse> RegistrarSolicitud(GrupoB2C grupo);
    }
}
