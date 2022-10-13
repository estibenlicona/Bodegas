using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using System.Linq.Expressions;

namespace Bodegas.Domain.Services
{
    public class CajaServices : ICajaServices
    {
        private readonly IGenericRepository<Caja> _genericRepository;

        public CajaServices(IGenericRepository<Caja> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Caja> Get(string cod_caj)
        {
            Expression<Func<Caja, bool>> condition = caja => caja.cod_bod == cod_caj;
            return await _genericRepository.Get(condition);
        }

        public async Task<List<Caja>> List(FilterArguments<Caja> arguments)
        {
            IQueryable<Caja> Query = _genericRepository.List();
            if(arguments.Where != null) Query = Query.Where(arguments.Where);
            await Task.CompletedTask;
            return Query.ToList();
        }

        public async Task AddAsync(Caja caja)
        {
            await _genericRepository.AddAsync(caja);
        }

        public async Task UpdateAsync(Caja caja)
        {
            await _genericRepository.UpdateAsync(caja);
        }
    }
}
