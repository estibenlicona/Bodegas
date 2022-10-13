using Bodegas.Domain.Enums;
using Bodegas.Domain.Helpers;
using MediatR;

namespace Bodegas.Applications.B2cService.Commands
{
    public class B2CCommand : IRequest<ApiAliadosResponse>
    {
        public string CodigoCentroCosto { get; set; }
        public string NombreCentroCosto { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public decimal PorcentajeComision { get; set; }
        public bool Activo { get; set; }
        public EnumTipoCupo TipoCupo { get; set; }

        public B2CCommand(string codigoCentroCosto, string nombreCentroCosto, string codigoSucursal, string nombreSucursal, decimal porcentajeComision, bool activo, EnumTipoCupo tipoCupo )
        {
            CodigoCentroCosto = codigoCentroCosto;
            NombreCentroCosto = nombreCentroCosto;
            CodigoSucursal = codigoSucursal;
            NombreSucursal = nombreSucursal;
            PorcentajeComision = porcentajeComision;
            Activo = activo;
            TipoCupo = tipoCupo;
        }
    }
}
