export class Caja {
  codigo: string | null;
  nombre: string | null;
  bodega: string | null;
  centroCosto: string | null;
  prefijo: string | null;
  numeroActual: number | null;

  constructor() {
    this.codigo = null;
    this.nombre = null;
    this.bodega = null;
    this.centroCosto = null;
    this.prefijo = null;
    this.numeroActual = 0;
  }
}
