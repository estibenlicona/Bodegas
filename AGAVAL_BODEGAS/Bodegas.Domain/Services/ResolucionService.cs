using Bodegas.Domain.Entities;
using Bodegas.Domain.Ports;
using System.Linq.Expressions;

namespace Bodegas.Domain.Services
{
    public class ResolucionService : IResolucionlServices
    {
        private readonly IGenericRepository<Resolucion> _genericRepository;

        public ResolucionService(IGenericRepository<Resolucion> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Resolucion> Get(string CodigoCaja)
        {
            Expression<Func<Resolucion, bool>> condition = resolucion => resolucion.CodigoCaja == CodigoCaja;
            Resolucion Resolucion = await _genericRepository.Get(condition);
            return Resolucion;
        }

        public async Task AddAsync(Resolucion Resolucion)
        {
            await _genericRepository.AddAsync(Resolucion);
        }

        public async Task UpdateAsync(Resolucion Resolucion)
        {
            await _genericRepository.UpdateAsync(Resolucion);
        }
    }
}
