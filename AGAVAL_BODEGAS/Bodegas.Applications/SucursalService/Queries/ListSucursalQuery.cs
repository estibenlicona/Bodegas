using Bodegas.Domain.DTOs;
using MediatR;

namespace Bodegas.Applications.SucrusalService.Queries
{
    public class ListSucursalQuery : IRequest<List<SucursalDto>>
    {
        public string? Text { get; set; } = default!;
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;

    }
}
