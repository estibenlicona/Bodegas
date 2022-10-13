using AutoMapper;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.TerceroService.Queries
{
    public class BuscarTercerosQueryHandler : IRequestHandler<BuscarTercerosQuery, List<TerceroDto>>
    {
        private readonly ITerceroService _terceroService;
        private readonly IMapper _mapper;
        public BuscarTercerosQueryHandler(ITerceroService terceroService, IMapper mapper)
        {
            _terceroService = terceroService;
            _mapper = mapper;
        }

        public async Task<List<TerceroDto>> Handle(BuscarTercerosQuery request, CancellationToken cancellationToken)
        {
            FilterArguments<Tercero> FilterArguments = new FilterArguments<Tercero>()
            {
                Text = request.Nit,
                Page = request.Page,
                Size = request.Limit
            };

            List<Tercero> Terceros = await _terceroService.List(FilterArguments);
            List<TerceroDto> TercerosDto = _mapper.Map<List<TerceroDto>>(Terceros);
            return TercerosDto;
        }
    }
}
