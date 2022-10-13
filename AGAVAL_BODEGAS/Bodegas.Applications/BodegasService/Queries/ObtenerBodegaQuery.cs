using Bodegas.Domain.DTOs;
using MediatR;

namespace Bodegas.Applications.BodegasService.Queries
{
    public class ObtenerBodegaQuery : IRequest<BodegaDto>
    {
        public string Codigo { get; set; } = default!;
    }
}
