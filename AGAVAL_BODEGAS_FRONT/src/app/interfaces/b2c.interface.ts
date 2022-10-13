import { EnumTipoCupo } from "../enums/tipocupo.enum";

export interface IB2C {
  codigoCentroCosto: string | null;
  nombreCentroCosto: string | null;
  codigoSucursal: string | null;
  nombreSucursal: string | null | undefined;
  porcentajeComision: number | null | undefined;
  tipoCupo: EnumTipoCupo | null | undefined | string;
}
