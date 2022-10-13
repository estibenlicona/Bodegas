export class Resolucion {
    numeroResolucion: string | null;
    fecha: string | Date | null;
    resolucionInicial: string | null;
    resolucionFinal: string | null;
    codigoAplicacion: string | null;
    codigoContable: string | null;
    prefijo: string | null;
    caja?: string | null;
    descripcion?: string;

    constructor() {
      this.caja = null;
      this.numeroResolucion = null;
      this.fecha = null;
      this.resolucionInicial = null;
      this.resolucionFinal = null;
      this.codigoAplicacion = null;
      this.codigoContable = null;
      this.prefijo = null;
    }
}
