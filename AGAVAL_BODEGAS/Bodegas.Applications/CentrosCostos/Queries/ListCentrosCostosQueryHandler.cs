using AutoMapper;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.CentrosCostos.Queries
{
    public class ListCentrosCostosQueryHandler : IRequestHandler<ListCentrosCostoQuery, List<CentroCostoDto>>
    {
        private readonly ICentroCostoService _centroCostoService;
        private readonly IMapper _mapper;
        public ListCentrosCostosQueryHandler(ICentroCostoService centroCostoService, IMapper mapper)
        {
            _centroCostoService = centroCostoService;
            _mapper = mapper;
        }

        public async Task<List<CentroCostoDto>> Handle(ListCentrosCostoQuery request, CancellationToken cancellationToken)
        {
            FilterArguments<CentroCosto> FilterArguments = new FilterArguments<CentroCosto>()
            {
                Text = request.Text,
                Page = request.Page,
                Size = request.Size
            };

            List<CentroCosto> CentrosCostos = await _centroCostoService.List(FilterArguments);
            List<CentroCostoDto> CentrosCostosDto = _mapper.Map<List<CentroCostoDto>>(CentrosCostos);
            return CentrosCostosDto;
        }
    }
}
