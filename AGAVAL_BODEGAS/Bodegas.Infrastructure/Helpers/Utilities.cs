using Bodegas.Domain.Entities;
using Newtonsoft.Json;

namespace Bodegas.Infrastructure.Helpers
{
    public static class Utilities
    {
        public static List<Sucursal> GetSeedSucursales()
        {
            List<Sucursal> Sucursales = ReadJson<List<Sucursal>>("SeedSucursalesTest") ?? new List<Sucursal>();
            return Sucursales;
        }

        public static List<CentroCosto> GetSeedCentrosCostos()
        {
            List<CentroCosto> CentroCostos = ReadJson<List<CentroCosto>>("SeedCentroCostoTest") ?? new List<CentroCosto>();
            return CentroCostos;
        }

        public static List<Bodega> GetSeedBodegas()
        {
            List<Bodega> Bodegas = ReadJson<List<Bodega>>("SeedBodegasTest") ?? new List<Bodega>();
            return Bodegas;
        }
        public static List<BodegaAliado> GetSeedBodegasAliados()
        {
            List<BodegaAliado> BodegasAliados = ReadJson<List<BodegaAliado>>("SeedBodegasAliadosTest") ?? new List<BodegaAliado>();
            return BodegasAliados;
        }
        public static List<Resolucion> GetSeedResoluciones()
        {
            List<Resolucion> Resoluciones = ReadJson<List<Resolucion>>("SeedResolucionesTest") ?? new List<Resolucion>();
            return Resoluciones;
        }
        public static List<Caja> GetSeedCajas()
        {
            List<Caja> Cajas = ReadJson<List<Caja>>("SeedCajasTest") ?? new List<Caja>();
            return Cajas;
        }
        public static T? ReadJson<T>(string Name)
        {
            T? results = JsonConvert.DeserializeObject<T>(File.ReadAllText($"JsonsSeeds/{Name}.json"));
            return results;
        }

        public static List<Tercero> GetSeedTerceros()
        {
            return new List<Tercero>()
            {
                new Tercero(){ Identificacion = "1028030380", Nombre = "TERCERO 1" },
                new Tercero(){ Identificacion = "1028030381", Nombre = "TERCERO 2" },
                new Tercero(){ Identificacion = "1028030382", Nombre = "TERCERO 3" },
                new Tercero(){ Identificacion = "1028030383", Nombre = "TERCERO 4" },
                new Tercero(){ Identificacion = "1028030384", Nombre = "TERCERO 5" },
                new Tercero(){ Identificacion = "1028030385", Nombre = "TERCERO 6" },
                new Tercero(){ Identificacion = "1028030386", Nombre = "TERCERO 7" },
                new Tercero(){ Identificacion = "1028030387", Nombre = "TERCERO 8" },
                new Tercero(){ Identificacion = "1028030388", Nombre = "TERCERO 9" },
                new Tercero(){ Identificacion = "1028030389", Nombre = "TERCERO 10" },
                new Tercero(){ Identificacion = "1028030390", Nombre = "TERCERO 11" },
                new Tercero(){ Identificacion = "1028030391", Nombre = "TERCERO 12" },
                new Tercero(){ Identificacion = "1028030392", Nombre = "TERCERO 13" }
            };
        }
    }
}
