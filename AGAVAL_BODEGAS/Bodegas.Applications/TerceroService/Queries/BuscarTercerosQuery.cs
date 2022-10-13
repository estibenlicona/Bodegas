using Bodegas.Domain.DTOs;
using MediatR;

namespace Bodegas.Applications.TerceroService.Queries
{
    public class BuscarTercerosQuery : IRequest<List<TerceroDto>>
    {
        public string? Nit { get; set; } = default!;
        public int Page { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
