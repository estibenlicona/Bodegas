using Bodegas.Applications.SucrusalService.Queries;
using Bodegas.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : Controller
    {
        private readonly IMediator _mediator;
        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SucursalDto>> List([FromQuery] ListSucursalQuery query)
        {
            List<SucursalDto> SucursalesDto = await _mediator.Send(query);
            return SucursalesDto.ToList();
        }
    }
}
