using AutoMapper;
using Bodegas.Applications.SucrusalService.Queries;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.SucursalService.Queries
{
    public class ListSucursalQueryHandler : IRequestHandler<ListSucursalQuery, List<SucursalDto>>
    {
        private readonly ISucursalService _sucursalService;
        private readonly IMapper _mapper;
        public ListSucursalQueryHandler(ISucursalService sucursalService, IMapper mapper)
        {
            _sucursalService = sucursalService;
            _mapper = mapper;
        }

        public async Task<List<SucursalDto>> Handle(ListSucursalQuery request, CancellationToken cancellationToken)
        {
            FilterArguments<Sucursal> FilterArguments = new FilterArguments<Sucursal>()
            {
                Text = request.Text,
                Page = request.Page,
                Size = request.Size
            };

            List<Sucursal> Sucursales = await _sucursalService.List(FilterArguments);
            List<SucursalDto> SucursalesDto = _mapper.Map<List<SucursalDto>>(Sucursales);
            return SucursalesDto;
        }
    }
}
