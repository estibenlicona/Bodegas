using Bodegas.Domain.Enums;

namespace Bodegas.Domain.Entities
{
    public class GrupoB2C
    {
        public string CodigoCentroCostos { get; set; }
        public string NombreCentroCostos { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public decimal Comision { get; set; }
        public bool Activo { get; set; }
        public EnumTipoCupo TipoCupo { get; set; }

        public GrupoB2C(string codigoCentroCostos, string nombreCentroCostos, string codigoSucursal, string nombreSucursal, decimal comision, bool activo, EnumTipoCupo tipoCupo)
        {
            CodigoCentroCostos = codigoCentroCostos;
            NombreCentroCostos = nombreCentroCostos;
            CodigoSucursal = codigoSucursal;
            NombreSucursal = nombreSucursal;
            Comision = comision;
            Activo = activo;
            TipoCupo = tipoCupo;
        }
    }
}
