using Bodegas.Domain.DTOs;
using MediatR;

namespace Bodegas.Applications.CentrosCostos.Queries
{
    public class ListCentrosCostoQuery : IRequest<List<CentroCostoDto>>
    {
        public string? Text { get; set; } = default!;
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;
    }
}
