using Bodegas.Domain.DTOs;
using Bodegas.Domain.Helpers;
using MediatR;

namespace Bodegas.Applications.BodegasService.Queries
{
    public class ListarBodegaQuery : IRequest<ApiResponse<List<BodegaDto>>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;
        public string? Sort { get; set; } = "Codigo";
        public string? Direction { get; set; } = "desc";
        public string? Column { get; set; } = default!;
        public string? Filter { get; set; } = default!;
        public string? Text { get; set; } = default!;
        public string? Start { get; set; } = default!;
        public string? End { get; set; } = default!;

    }
}
