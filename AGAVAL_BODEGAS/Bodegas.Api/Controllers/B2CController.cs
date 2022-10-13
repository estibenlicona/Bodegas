using Bodegas.Applications.B2cService.Commands;
using Bodegas.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class B2CController : Controller
    {
        private readonly IMediator _mediator;

        public B2CController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registro")]
        public async Task<ApiResponse<bool>> Post([FromBody] B2CCommand command)
        {
            ApiAliadosResponse apiAliadosResponse = await _mediator.Send(command);
            return new ApiResponse<bool>(apiAliadosResponse.Message, true);
        }
    }
}
