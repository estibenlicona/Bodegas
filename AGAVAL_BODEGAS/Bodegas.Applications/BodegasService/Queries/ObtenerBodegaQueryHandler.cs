using AutoMapper;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.BodegasService.Queries
{
    public class ObtenerCajaQueryHandler : IRequestHandler<ObtenerBodegaQuery, BodegaDto>
    {
        private readonly IBodegaServices _bodegaService;
        private readonly IMapper _mapper;
        public ObtenerCajaQueryHandler(IBodegaServices bodegaService, IMapper mapper)
        {
            _bodegaService = bodegaService;
            _mapper = mapper;
        }
        public async Task<BodegaDto> Handle(ObtenerBodegaQuery request, CancellationToken cancellationToken)
        {
            Bodega bodega = await _bodegaService.GetAsync(request.Codigo);
            BodegaDto bodegaDto = _mapper.Map<BodegaDto>(bodega);
            return bodegaDto;
        }
    }
}
