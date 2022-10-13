using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;

namespace Bodegas.Domain.Services
{
    public class CentroCostoService : ICentroCostoService
    {
        private readonly IGenericRepository<CentroCosto> _centroCostoRespository;

        public CentroCostoService(IGenericRepository<CentroCosto> centroCostoRespository)
        {
            _centroCostoRespository = centroCostoRespository;
        }

        public async Task<List<CentroCosto>> List(FilterArguments<CentroCosto> args)
        {
            IQueryable<CentroCosto> Query = _centroCostoRespository.List();

            //Filtrar
            Query = Where(Query, args);

            //Paginar
            Query = Query.Skip(args.Size * args.Page).Take(args.Size);

            await Task.CompletedTask;

            return Query.ToList();
        }

        public static IQueryable<CentroCosto> Where(IQueryable<CentroCosto> Query, FilterArguments<CentroCosto> Args)
        {
            if (Args != null && Args.Text != null)
            {
                string text = Args.Text.Trim().ToLower();
                Query = Query.Where(cco => cco.Codigo.Trim().ToLower().StartsWith(text) || cco.nom_cco.Trim().ToLower().Contains(text));
            }
            return Query;
        }
    }
}
