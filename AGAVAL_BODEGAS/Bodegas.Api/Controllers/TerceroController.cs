using Bodegas.Applications.TerceroService.Queries;
using Bodegas.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : Controller
    {
        private readonly IMediator _mediator;

        public TerceroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TerceroDto>> Get([FromQuery] BuscarTercerosQuery query)
        {
            List<TerceroDto> terceros = await _mediator.Send(query);
            return terceros;
        }
    }
}
