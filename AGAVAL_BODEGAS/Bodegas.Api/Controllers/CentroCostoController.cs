using Bodegas.Applications.CentrosCostos.Queries;
using Bodegas.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CentroCostoController : Controller
    {
        private readonly IMediator _mediator;
        public CentroCostoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CentroCostoDto>> List([FromQuery] ListCentrosCostoQuery query)
        {
            List<CentroCostoDto> CentrosCostos = await _mediator.Send(query);

            return CentrosCostos.ToList();
        }
    }
}
