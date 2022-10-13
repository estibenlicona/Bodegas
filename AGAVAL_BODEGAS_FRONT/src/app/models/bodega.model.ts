import { ISucursal } from "../interfaces/sucursal.interface";
import { Caja } from "./caja.model";
import { InformacionAliado } from "./informacion-aliado.model";
import { Resolucion } from "./resolucion.model";

export class Bodega {
  codigo : string | null;
  codigoSucursal : string | null;
  sucursal: ISucursal | undefined;
  nombre : string | null;
  direccion : string | null;
  telefono : string | null;
  centroCosto : string | null;
  nit : string | null;
  codigoCiudad : string | null;
  validaReferencias : number | boolean | null;
  numeroActual: number | null;
  codigoCaja: string | null;

  cajaDto?: Caja;
  resolucionDto?: Resolucion;
  informacionAliadoDto?: InformacionAliado;

  constructor() {
    this.codigo = null;
    this.codigoSucursal = null;
    this.nombre = null;
    this.direccion = null;
    this.telefono = null;
    this.centroCosto = null;
    this.codigoCaja = null;
    this.nit = null;
    this.codigoCiudad = null;
    this.validaReferencias = 0;
    this.numeroActual = 0;
  }
}
