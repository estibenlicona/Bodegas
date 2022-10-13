using AutoMapper;
using Bodegas.Domain.Entities;
using Bodegas.Domain.Helpers;
using Bodegas.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace Bodegas.Domain.Services
{
    public class BodegaServices : IBodegaServices
    {
        private readonly IGenericRepository<Bodega> _bodegaRepository;
        private readonly IGenericRepository<BodegaAliado> _bodegaAliadoRepository;
        private readonly IGenericRepository<Caja> _cajaRepository;
        private readonly IGenericRepository<Resolucion> _resolucionRepository;
        private readonly IGenericRepository<CentroCosto> _centroCostoRepository;

        public BodegaServices(
            IGenericRepository<Bodega> bodegaRepository, 
            IGenericRepository<BodegaAliado> bodegaAliadoRepository,
            IGenericRepository<Caja> cajaRepository,
            IGenericRepository<Resolucion> resolucionRepository,
            IGenericRepository<CentroCosto> centroCostoRepository)
        {
            _bodegaRepository = bodegaRepository;
            _bodegaAliadoRepository = bodegaAliadoRepository;
            _cajaRepository = cajaRepository;
            _resolucionRepository = resolucionRepository;
            _centroCostoRepository = centroCostoRepository;
        }

        public async Task AddAsync(Bodega bodega)
        {
            await _bodegaRepository.AddAsync(bodega);
            await _cajaRepository.AddAsync(bodega.Caja);
            await _resolucionRepository.AddAsync(bodega.Resolucion);
            await UpdateCentroCosto(bodega.Codigo, bodega.Nombre);
        }

        public async Task UpdateAsync(Bodega bodega)
        {
            await _bodegaRepository.UpdateAsync(bodega);
            await _bodegaAliadoRepository.UpdateAsync(bodega.BodegaAliado);
            await UpdateCentroCosto(bodega.Codigo, bodega.Nombre);
        }
        public async Task UpdateCentroCosto(string codigo, string nombre)
        {
            CentroCosto centroCosto = new CentroCosto()
            {
                Codigo = codigo,
                nom_cco = nombre
            };

            await _centroCostoRepository.UpdateAsync(centroCosto);
        }

        public async Task<Bodega> GetAsync(string cod_bod)
        {
            Expression<Func<Bodega, bool>> condition = bodega => bodega.Codigo == cod_bod;
            Bodega Bodega = await _bodegaRepository.Get(condition, "Sucursal,BodegaAliado");
            
            return Bodega;
        }

        public async Task<Tuple<int, List<Bodega>>> ListAsync(FilterArguments<Bodega> arguments)
        {
            IQueryable<Bodega> Query = _bodegaRepository.List("Sucursal,BodegaAliado");
            Query = Query.Where(x => x.Formato.Trim().ToLower().Equals("aliado"));

            //Filtrar
            Query = Where(Query, arguments);
            
            //Total
            int count = Query.Count();

            //Ordenar
            Query = Sorted(Query, arguments);

            //Paginar
            if(arguments != null) Query = Query.Skip(arguments.Size * arguments.Page).Take(arguments.Size);

            List<Bodega> Bodegas = Query.ToList();
            await Task.CompletedTask;
            return new Tuple<int, List<Bodega>>(count, Bodegas);
        }

        public static IQueryable<Bodega> Where(IQueryable<Bodega> Query, FilterArguments<Bodega> args)
        {
            if (args != null && args.Filter != null && args.Column != null)
            {
                if (args.Filter == "" || args.Column == "") return Query;
                if (args.Filter == "Igual") Query = Query.WhereDynamic(x => $"x.{args.Column} == Text", args);
                if (args.Filter == "Diferente") Query = Query.WhereDynamic(x => $"x.{args.Column} != Text", args);
                if (args.Filter == "Contiene") Query = Query.WhereDynamic(x => $"x.{args.Column}.Contains(Text)", args);
                if (args.Filter == "Mayor que") Query = Query.WhereDynamic(x => $"x.{args.Column} > Text", args);
                if (args.Filter == "Mayor igual que") Query = Query.WhereDynamic(x => $"x.{args.Column} >= Text", args);
                if (args.Filter == "Menor que") Query = Query.WhereDynamic(x => $"x.{args.Column} < Text", args);
                if (args.Filter == "Menor igual que") Query = Query.WhereDynamic(x => $"x.{args.Column} <= Text", args);
                if (args.Filter == "Entre" && args.Start != null && args.End != null) Query = Query.WhereDynamic(x => $"x.{args.Column} >= Start && x.{args.Column} <= End", new { Start = DateTime.Parse(args.Start), End = DateTime.Parse(args.End) });

            }

            return Query;
        }

        public static IQueryable<Bodega> Sorted(IQueryable<Bodega> Query, FilterArguments<Bodega> args)
        {
            if (args != null && args.Sort != null && args.Direction != null)
            {
                if (args.Sort == "" || args.Direction == "") return Query;
                if (args.Direction == "desc") Query = Query.OrderByDescendingDynamic(x => $"x.{args.Sort}", args);
                if (args.Direction == "asc") Query = Query.OrderByDynamic(x => $"x.{args.Sort}", args);
            }
            
            return Query;
        }
    }
}
