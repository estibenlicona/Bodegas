using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;

namespace Bodegas.Domain.Services
{
    public class TerceroService : ITerceroService
    {
        private readonly IGenericRepository<Tercero> _terceroRespository;
        public TerceroService(IGenericRepository<Tercero> terceroRespository)
        {
            _terceroRespository = terceroRespository;
        }

        public async Task<List<Tercero>> List(FilterArguments<Tercero> args)
        {
            IQueryable<Tercero> Query = _terceroRespository.List();

            //Filtrar
            Query = Where(Query, args);

            //Paginar
            Query = Query.Skip(args.Size * args.Page).Take(args.Size);

            await Task.CompletedTask;

            return Query.ToList();

        }

        public static IQueryable<Tercero> Where(IQueryable<Tercero> Query, FilterArguments<Tercero> Args)
        {
            
            if (Args != null && Args.Text != null)
            {
                string text = Args.Text.Trim().ToLower();
                Query = Query.Where(tercero => tercero.Identificacion.Trim().StartsWith(text));
            }
            return Query;
        }
    }
}
