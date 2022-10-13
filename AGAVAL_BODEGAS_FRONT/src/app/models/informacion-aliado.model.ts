export class InformacionAliado {
  emailContable: string | null;
  porcentjeComision: number | null;
  sector: string | null;
  representanteLegal: string | null;
  inicioFacturacion: string | Date | null;
  diasPago: number | null;
  activo: boolean | null;
  recibeAbonos: number | boolean | null;
  recibeAbonoAgaval: number | boolean | null;
  recibeAbonoTienda: number | boolean | null;
  recibeAbonoComercio: number | boolean | null;
  fechaActivacion: string | Date | null;
  fechaInActivacion: string | null | Date;
  tipoCupo: string | null;
  codigoBodega?: string | null;


  constructor() {
    this.emailContable = null;
    this.codigoBodega = null;
    this.porcentjeComision = null;
    this.sector = null;
    this.representanteLegal = null
    this.inicioFacturacion = null;
    this.diasPago = null;
    this.activo = true;
    this.recibeAbonos = 0;
    this.recibeAbonoTienda = false;
    this.recibeAbonoAgaval = false;
    this.recibeAbonoComercio = false;
    this.fechaActivacion = new Date();
    this.fechaInActivacion = null;
    this.tipoCupo = null;
  }
}
