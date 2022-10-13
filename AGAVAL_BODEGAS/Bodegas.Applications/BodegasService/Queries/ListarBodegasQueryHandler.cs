using AutoMapper;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.BodegasService.Queries
{
    public class ListarBodegasQueryHandler : IRequestHandler<ListarBodegaQuery, ApiResponse<List<BodegaDto>>>
    {
        private readonly IBodegaServices _bodegaService;
        private readonly IMapper _mapper;

        public ListarBodegasQueryHandler(IBodegaServices bodegaService, IMapper mapper)
        {
            _bodegaService = bodegaService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<BodegaDto>>> Handle(ListarBodegaQuery request, CancellationToken cancellationToken)
        {
            FilterArguments<Bodega> FilterArguments = new FilterArguments<Bodega>()
            {
                Page = request.Page,
                Size = request.Size,
                Sort = request.Sort,
                Direction = request.Direction,
                Column = request.Column,
                Filter = request.Filter,
                Text = request.Text,
                Start = request.Start,
                End = request.End
            };

            Tuple<int, List<Bodega>> list = await _bodegaService.ListAsync(FilterArguments);

            List<BodegaDto> bodegaDtos = _mapper.Map<List<BodegaDto>>(list.Item2);
            ApiResponse<List<BodegaDto>> apiResponse = new("Bodegas cargadas correctamente", true)
            {
                Body = bodegaDtos,
                Count = list.Item1
            };

            return apiResponse;
        }
    }
}
