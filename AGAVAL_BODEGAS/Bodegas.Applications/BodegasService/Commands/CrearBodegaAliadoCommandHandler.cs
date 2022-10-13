using AutoMapper;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Ports;
using MediatR;

namespace Bodegas.Applications.BodegasService.Commands
{
    public class CrearBodegaAliadoCommandHandler : AsyncRequestHandler<CrearBodegaAliadoCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBodegaServices _bodegaServices;
        public CrearBodegaAliadoCommandHandler(IMapper mapper, IBodegaServices bodegaServices)
        {
            _mapper = mapper;
            _bodegaServices = bodegaServices;
        }

        protected override async Task Handle(CrearBodegaAliadoCommand request, CancellationToken cancellationToken)
        {
            Bodega bodega = _mapper.Map<Bodega>(request);
            await _bodegaServices.AddAsync(bodega);
        }
    }
}
