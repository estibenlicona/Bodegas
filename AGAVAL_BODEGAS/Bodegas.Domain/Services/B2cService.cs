using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;

namespace Bodegas.Domain.Services
{
    public class B2CService : IB2CService
    {
        private readonly IB2CRepository _b2cRepository;
        public B2CService(IB2CRepository b2cRepository)
        {
            _b2cRepository = b2cRepository;
        }
        public async Task<ApiAliadosResponse> RegistrarSolicitud(GrupoB2C grupo)
        {
            return await _b2cRepository.PostAsync(grupo);
        }
    }
}
