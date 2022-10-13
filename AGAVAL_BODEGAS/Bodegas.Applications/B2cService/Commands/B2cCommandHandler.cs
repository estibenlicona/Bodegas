using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.B2cService.Commands
{
    public class B2CCommandHandler : IRequestHandler<B2CCommand, ApiAliadosResponse>
    {
        private readonly IB2CService _b2CService;
        public B2CCommandHandler(IB2CService b2CService)
        {
            _b2CService = b2CService;
        }

        public async Task<ApiAliadosResponse> Handle(B2CCommand request, CancellationToken cancellationToken)
        {
            GrupoB2C b2c = new GrupoB2C
            (
                codigoCentroCostos: request.CodigoCentroCosto,
                nombreCentroCostos: request.NombreCentroCosto,
                codigoSucursal: request.CodigoSucursal,
                nombreSucursal: request.NombreSucursal,
                comision: request.PorcentajeComision,
                activo: request.Activo,
                tipoCupo: request.TipoCupo
            );

            ApiAliadosResponse apiAliadosResponse = await _b2CService.RegistrarSolicitud(b2c);

            return apiAliadosResponse;
        }
    }
}
