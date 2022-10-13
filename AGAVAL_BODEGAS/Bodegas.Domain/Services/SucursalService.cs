using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;

namespace Bodegas.Domain.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly IGenericRepository<Sucursal> _sucursalRepository;
        
        public SucursalService(IGenericRepository<Sucursal> sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public async Task<List<Sucursal>> List(FilterArguments<Sucursal> args)
        {
            IQueryable<Sucursal> Query = _sucursalRepository.List();

            //Filtrar
            Query = Where(Query, args);

            //Paginar
            Query = Query.Skip(args.Size * args.Page).Take(args.Size);

            await Task.CompletedTask;

            return Query.ToList();

        }

        public static IQueryable<Sucursal> Where(IQueryable<Sucursal> Query, FilterArguments<Sucursal> Args)
        {            
            if (Args != null && Args.Text != null)
            {
                string text = Args.Text.Trim().ToLower();
                Query = Query.Where(suc => suc.Codigo.Trim().ToLower().StartsWith(text) || (suc.Nombre != null && suc.Nombre.Trim().ToLower().Contains(text)));
            }
            return Query;
        }
    }
}
