using AutoMapper;
using Bodegas.Applications.BodegasService.Commands;
using Bodegas.Applications.BodegasService.Queries;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : Controller
    {
        private readonly IMediator _mediator;

        public BodegasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<JsonResult> List([FromQuery] ListarBodegaQuery query)
        {
            ApiResponse<List<BodegaDto>> response = await _mediator.Send(query);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CrearBodegaAliadoCommand command)
        {
            await _mediator.Send(command);
            var resp = new ApiResponse<bool>("La bodega fue creada correctamente.", true);
            return Json(resp);

        }

        [HttpPut]
        public async Task<JsonResult> Put([FromBody] ActualizarBodegaAliadoCommand command)
        {
            await _mediator.Send(command);
            var resp = new ApiResponse<bool>("La bodega fue actualizada correctamente.", true);
            return Json(resp);
        }

        [HttpGet("{codigo}")]
        public async Task<BodegaDto> Get(string codigo)
        {
            return await _mediator.Send(new ObtenerBodegaQuery() { Codigo = codigo });
        }
    }
}
