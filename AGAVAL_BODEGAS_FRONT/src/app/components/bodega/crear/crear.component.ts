import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { ICentroCosto } from 'src/app/interfaces/centro-costo.interface';
import { ISucursal } from 'src/app/interfaces/sucursal.interface';
import { ITercero } from 'src/app/interfaces/tercero.interface';
import { CentrocostoService } from 'src/app/services/centrocosto.service';
import { SucursalService } from 'src/app/services/sucursal.service';
import { TerceroService } from 'src/app/services/tercero.service';
import { DatePipe } from '@angular/common';
import { BodegaService } from 'src/app/services/bodega.service';
import { ActivatedRoute } from '@angular/router';
import { Bodega } from 'src/app/models/bodega.model';
import { Caja } from 'src/app/models/caja.model';
import { InformacionAliado } from 'src/app/models/informacion-aliado.model';
import { Resolucion } from 'src/app/models/resolucion.model';
import { AlertService } from 'src/app/services/alert.service';
import { IB2C } from 'src/app/interfaces/b2c.interface';
import { B2cService } from 'src/app/services/b2c.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-centro-costo-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.css'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { showError: true },
    },
  ],
})
export class CrearBodegaComponent implements OnInit {
  pipe = new DatePipe('en-US');
  @ViewChild('inputCco') inputCco!: ElementRef;
  spinner: boolean = false;
  centroscostos!: Array<ICentroCosto>;
  sucursales!: Array<ISucursal>;
  terceros!: Array<ITercero>;
  nitTerceroTest = new FormControl('');
  activeBtnSearchTercero: boolean = false;
  actualizar: boolean = false;
  nombreSucursal: string = "";
  bodegaActual: Bodega;

  formBodega = this._formBuilder.group<Bodega>(new Bodega());
  formInfoAliado = this._formBuilder.group<InformacionAliado>(new InformacionAliado());
  formResolucion = this._formBuilder.group<Resolucion>(new Resolucion());

  constructor(
    private _formBuilder: FormBuilder,
    private _centroCostos: CentrocostoService,
    private _sucursal: SucursalService,
    private _tercero: TerceroService,
    private _bodega: BodegaService,
    private rutaActiva: ActivatedRoute,
    private _alert: AlertService,
    private _b2c: B2cService
  ) {
    this.bodegaActual = new Bodega();
  }

  ngOnInit(): void {
    this.addValidatorsFormBodega();
    this.addValidatorsFormInfoAliado();
    this.addValidatorsFormResolucion();

    if(this.rutaActiva.snapshot.params['codigo'] != undefined){
      this.actualizar = true;
      this.editMode(this.rutaActiva.snapshot.params['codigo']);
    }

    this.formBodega.controls.codigo.disable();
    this.formInfoAliado.controls.fechaActivacion.disable();
    this.formInfoAliado.controls.fechaInActivacion.disable();
    this.formResolucion.controls.resolucionInicial.disable();
    this.formResolucion.controls.resolucionFinal.disable();
    this.formResolucion.controls.codigoAplicacion.disable();
    this.formResolucion.controls.codigoContable.disable();

    this.formBodega.controls.centroCosto.valueChanges.subscribe((value) => {
      this._filterCentroCosto(value)
    });
    this.formBodega.controls.codigoSucursal.valueChanges.subscribe((value) => this._filterSucursal(value));
    this.formBodega.controls.nit.valueChanges.subscribe((value) => this._activeSearchTercero(value));

   this.formInfoAliado.controls.recibeAbonoTienda.valueChanges.subscribe(value => {
    if(value && this.formInfoAliado.controls.recibeAbonoComercio.value){
      this.formInfoAliado.controls.recibeAbonoTienda.setValue(false);
      this.formInfoAliado.controls.recibeAbonoComercio.setValue(false);
      this._alert.sweetAlert('warning', 'No es posible escoger esta combinación.');
    }
   });

   this.formInfoAliado.controls.recibeAbonoComercio.valueChanges.subscribe(value => {
    if(value && this.formInfoAliado.controls.recibeAbonoTienda.value){
      this.formInfoAliado.controls.recibeAbonoTienda.setValue(false);
      this.formInfoAliado.controls.recibeAbonoComercio.setValue(false);
      this._alert.sweetAlert('warning', 'No es posible escoger esta combinación.');
    }
   });
  }

  addValidatorsFormBodega(){
    this.formBodega.controls.codigo.addValidators([Validators.required, Validators.maxLength(3)]);
    this.formBodega.controls.codigoCaja.addValidators([Validators.required, Validators.maxLength(3)]);
    this.formBodega.controls.centroCosto.addValidators([Validators.required, Validators.maxLength(3)]);
    this.formBodega.controls.codigoSucursal.addValidators([Validators.required, Validators.maxLength(3)]);
    this.formBodega.controls.nit.addValidators([Validators.required, Validators.maxLength(15)]);
    this.formBodega.controls.nombre.addValidators([Validators.required, Validators.maxLength(30)]);
    this.formBodega.controls.codigoCiudad.addValidators([Validators.required, Validators.maxLength(20)]);
    this.formBodega.controls.direccion.addValidators([Validators.required, Validators.maxLength(80)]);
    this.formBodega.controls.telefono.addValidators([Validators.required, Validators.maxLength(10)]);
  }

  addValidatorsFormInfoAliado(){
    this.formInfoAliado.controls.emailContable.addValidators([Validators.required, Validators.maxLength(100)]);
    this.formInfoAliado.controls.sector.addValidators([Validators.required, Validators.maxLength(50)]);
    this.formInfoAliado.controls.representanteLegal.addValidators([Validators.required, Validators.maxLength(50)]);
    this.formInfoAliado.controls.porcentjeComision.addValidators([Validators.required, Validators.pattern("^[0-9]|[.]+\.?[0-9]*")]);
    this.formInfoAliado.controls.diasPago.addValidators([Validators.required]);
    this.formInfoAliado.controls.tipoCupo.addValidators([Validators.required, Validators.maxLength(50)]);
    this.formInfoAliado.controls.fechaActivacion.addValidators([Validators.required]);
  }

  addValidatorsFormResolucion(){
    this.formResolucion.controls.numeroResolucion.addValidators([Validators.required, Validators.maxLength(15)]);
    this.formResolucion.controls.fecha.addValidators([Validators.required]);
    this.formResolucion.controls.resolucionInicial.addValidators([Validators.required, Validators.maxLength(10)]);
    this.formResolucion.controls.resolucionFinal.addValidators([Validators.required, Validators.maxLength(10)]);
    this.formResolucion.controls.codigoAplicacion.addValidators([Validators.required, Validators.maxLength(3)]);
    this.formResolucion.controls.codigoContable.addValidators([Validators.required, Validators.maxLength(3)]);
  }

  editMode(codigo: string){
    this._bodega.getBodega(codigo).subscribe((bodega: Bodega) => {
        this.bodegaActual = bodega;
        this.setFormBodega(bodega);
        if(bodega.informacionAliadoDto != undefined && bodega.informacionAliadoDto != null) this.setForminformacionAliado(bodega.informacionAliadoDto);
        if(bodega.resolucionDto != undefined && bodega.resolucionDto != null) this.setFormResolucion(bodega.resolucionDto);
    });
  }

  setFormBodega(bodega: Bodega){
    this.formBodega.controls.codigo.setValue(String(bodega.codigo).toUpperCase().trimEnd());
    this.formBodega.controls.codigoCaja.setValue(String(bodega.cajaDto?.codigo).toUpperCase().trimEnd());
    this.formBodega.controls.centroCosto.setValue(String(bodega.centroCosto).toUpperCase().trimEnd());
    this.formBodega.controls.codigoSucursal.setValue(String(bodega.codigoSucursal).toUpperCase().trimEnd());
    this.formBodega.controls.nit.setValue(String(bodega.nit).toUpperCase().trimEnd());
    this.formBodega.controls.nombre.setValue(String(bodega.nombre).toUpperCase().trimEnd());
    this.formBodega.controls.codigoCiudad.setValue(String(bodega.codigoCiudad).toUpperCase().trimEnd());
    this.formBodega.controls.direccion.setValue(String(bodega.direccion).toUpperCase().trimEnd());
    this.formBodega.controls.telefono.setValue(String(bodega.telefono).toUpperCase().trimEnd());
    this.formBodega.controls.validaReferencias.setValue(bodega.validaReferencias);
    this.formBodega.controls.centroCosto.disable();
    this.formBodega.controls.codigoCaja.disable();
    this.formBodega.controls.codigoSucursal.disable();
    this.formBodega.controls.nit.disable();
    this.formBodega.controls.codigoCiudad.disable();
  }

  setForminformacionAliado(informacionAliado: InformacionAliado){
    this.formInfoAliado.controls.emailContable.setValue(informacionAliado.emailContable);
    this.formInfoAliado.controls.sector.setValue(informacionAliado.sector);
    this.formInfoAliado.controls.representanteLegal.setValue(informacionAliado.representanteLegal);
    this.formInfoAliado.controls.inicioFacturacion.setValue(informacionAliado.inicioFacturacion);
    this.formInfoAliado.controls.porcentjeComision.setValue(informacionAliado.porcentjeComision);
    this.formInfoAliado.controls.diasPago.setValue(informacionAliado.diasPago);
    this.formInfoAliado.controls.recibeAbonos.setValue(informacionAliado.recibeAbonos);
    this.formInfoAliado.controls.tipoCupo.setValue(informacionAliado.tipoCupo);
    this.formInfoAliado.controls.activo.setValue(Boolean(informacionAliado.activo));
    this.formInfoAliado.controls.recibeAbonoAgaval.setValue(Boolean(informacionAliado.recibeAbonoAgaval));
    this.formInfoAliado.controls.recibeAbonoComercio.setValue(Boolean(informacionAliado.recibeAbonoComercio));
    this.formInfoAliado.controls.recibeAbonoTienda.setValue(Boolean(informacionAliado.recibeAbonoTienda));
    this.formInfoAliado.controls.fechaActivacion.setValue(informacionAliado.fechaActivacion);
    this.formInfoAliado.controls.fechaInActivacion.setValue(informacionAliado.fechaInActivacion);
    if(environment.production) this.formInfoAliado.controls.tipoCupo.disable();
  }

  setFormResolucion(resolucion: Resolucion){
    this.formResolucion.controls.numeroResolucion.setValue(String(resolucion.numeroResolucion).toUpperCase().trimEnd());
    this.formResolucion.controls.fecha.setValue(resolucion.fecha);
    this.formResolucion.controls.resolucionInicial.setValue(String(resolucion.resolucionInicial).toUpperCase().trimEnd());
    this.formResolucion.controls.resolucionFinal.setValue(String(resolucion.resolucionFinal).toUpperCase().trimEnd());
    this.formResolucion.controls.codigoAplicacion.setValue(String(resolucion.codigoAplicacion).toUpperCase().trimEnd());
    this.formResolucion.controls.codigoContable.setValue(String(resolucion.codigoContable).toUpperCase().trimEnd());
    this.formResolucion.controls.numeroResolucion.disable();
    this.formResolucion.controls.fecha.disable();
  }

  private _filterCentroCosto(value: string | null) {
    let filterValue = (!!value) ? value?.toLowerCase() : '';
    this._centroCostos.searchCentroCosto(filterValue).subscribe((centroscostos: Array<ICentroCosto>) => {
      this.centroscostos = centroscostos.filter(x => x.codigo != '0');
    });
  }

  private _filterSucursal(value: string | null) {
    let filterValue = (!!value) ? value?.toLowerCase() : '';
    this._sucursal.searchSucursal(filterValue).subscribe((sucursales: Array<ISucursal>) => {
      this.sucursales = sucursales.filter(x => x.codigo != '0' && x.codigo != '00');
    });
  }

  private _activeSearchTercero(value: string | null){
    let filterValue = (!!value) ? value?.toLowerCase() : '';
    if(filterValue.length >= 4) {
      this.activeBtnSearchTercero = true;
    }else {
      this.activeBtnSearchTercero = false;
    }
  }

  searchTercero(trigger: MatAutocompleteTrigger){
    let filterValue: string = String(this.formBodega.controls.nit.value);
    if(filterValue == null) return;
    this.spinner = true;
    this._tercero.search(filterValue).subscribe((terceros: Array<ITercero>) => {
      this.terceros = terceros;
      trigger.openPanel();
      this.spinner = false;
    });
  }

  valideNumberDecimal(event: KeyboardEvent) {
    let pattern: RegExp = /[0-9]|[.]/;
    if (!pattern.test(event.key)) event.preventDefault();
  }

  valideNumber(event: KeyboardEvent) {
    let pattern: RegExp = /[0-9]/;
    if (!pattern.test(event.key)) event.preventDefault();
  }

  MapearDatos(): Bodega {
    let bodega: Bodega = new Bodega();
    bodega.codigo = this.formBodega.controls.centroCosto.value;
    bodega.centroCosto = this.formBodega.controls.centroCosto.value;
    bodega.codigoSucursal = this.formBodega.controls.codigoSucursal.value;
    bodega.nit = this.formBodega.controls.nit.value;
    bodega.nombre = this.formBodega.controls.nombre.value;
    bodega.codigoCiudad = this.formBodega.controls.codigoCiudad.value;
    bodega.direccion = this.formBodega.controls.direccion.value;
    bodega.telefono = this.formBodega.controls.telefono.value;
    bodega.validaReferencias = Number(this.formBodega.controls.validaReferencias.value);
    bodega.numeroActual = this.bodegaActual.numeroActual;

    let informacionAliado: InformacionAliado = new InformacionAliado();
    informacionAliado.emailContable = this.formInfoAliado.controls.emailContable.value;
    informacionAliado.codigoBodega = bodega.codigo;
    informacionAliado.activo = this.formInfoAliado.controls.activo.value;
    informacionAliado.recibeAbonoAgaval = this.formInfoAliado.controls.recibeAbonoAgaval.value;
    informacionAliado.recibeAbonoComercio = this.formInfoAliado.controls.recibeAbonoComercio.value;
    informacionAliado.recibeAbonoTienda = this.formInfoAliado.controls.recibeAbonoTienda.value;
    informacionAliado.diasPago = this.formInfoAliado.controls.diasPago.value;
    informacionAliado.fechaActivacion = this.formInfoAliado.controls.fechaActivacion.value;
    informacionAliado.fechaInActivacion = this.formInfoAliado.controls.fechaInActivacion.value;
    informacionAliado.inicioFacturacion = this.formInfoAliado.controls.inicioFacturacion.value;
    const recibeabono: boolean = (informacionAliado.recibeAbonoAgaval || informacionAliado.recibeAbonoComercio || informacionAliado.recibeAbonoTienda) ? true : false;
    informacionAliado.recibeAbonos = Number(recibeabono);
    informacionAliado.porcentjeComision = this.formInfoAliado.controls.porcentjeComision.value;
    informacionAliado.representanteLegal = this.formInfoAliado.controls.representanteLegal.value;
    informacionAliado.sector = this.formInfoAliado.controls.sector.value;
    informacionAliado.tipoCupo = this.formInfoAliado.controls.tipoCupo.value;

    let caja: Caja = new Caja();
    caja.bodega = bodega.codigo;
    caja.centroCosto = bodega.codigo;
    caja.codigo = this.formBodega.controls.codigoCaja.value;
    caja.nombre = `CAJA${caja.codigo?.toUpperCase()}`;
    caja.prefijo = `A${caja.codigo?.toUpperCase()}`;


    let resolucion: Resolucion = new Resolucion()
    resolucion.caja = caja.codigo,
    resolucion.numeroResolucion = this.formResolucion.controls.numeroResolucion.value;
    resolucion.fecha = this.formResolucion.controls.fecha.value;
    resolucion.resolucionInicial = `${caja.prefijo}1`;
    resolucion.resolucionFinal = `${caja.prefijo}500000`;
    resolucion.codigoContable = '510';
    resolucion.codigoAplicacion = 'INV';
    resolucion.prefijo = caja.prefijo;

    bodega.informacionAliadoDto = informacionAliado;
    bodega.cajaDto = caja;
    bodega.resolucionDto = resolucion;

    return bodega;
  }

  validarFormularios(): boolean {
    if(this.formBodega.status === "INVALID" || this.formInfoAliado.status === "INVALID" || this.formResolucion.status === "INVALID") {
      this._alert.sweetAlert('warning', 'Por favor valida todos los datos.');
      return false;
    };

    return true;
  }

  Actualizar(){
    if(!this.validarFormularios()) return;
    this.spinner = true;
    let bodega: Bodega = this.MapearDatos();

    this._bodega.putBodega(bodega).subscribe(
      (resp) => {
        this.spinner = false;
        this._alert.sweetAlert('success', 'Datos actualizados correctamente.');
        this.sendB2c(bodega);
      },
      (error) => {
        this.spinner = false;
        this._alert.sweetAlert('error', 'Ha ocurrido un actualizando los datos.');
      },
      () => {
        this.spinner = false;
      });
  }

  Guardar(){

    if(!this.validarFormularios()) return;
    this.spinner = true;
    let bodega: Bodega = this.MapearDatos();

    this._bodega.postBodega(bodega).subscribe(
      (resp) => {
        this._alert.sweetAlert('success','Datos guardados correctamente.');
        this.sendB2c(bodega);
      },
      (error) => {
        this.spinner = false;
        this._alert.sweetAlert('error', 'Ha ocurrido un error guardando los datos.');
      },
      () => {
        this.spinner = false;
      });
  }

  sendB2c(bodega: Bodega){
    this.spinner = true;
    const nombreSucursal = this.sucursales.find(x => x.codigo == bodega.codigoSucursal)?.nombre;
    let b2c: IB2C = {
      codigoCentroCosto: bodega.centroCosto,
      codigoSucursal: bodega.codigoSucursal,
      nombreCentroCosto: bodega.nombre,
      nombreSucursal: nombreSucursal,
      porcentajeComision: bodega.informacionAliadoDto?.porcentjeComision,
      tipoCupo: bodega.informacionAliadoDto?.tipoCupo
    }
    this._b2c.postB2C(b2c).subscribe(resp => {
      this._alert.sweetAlert('success', 'Centro de costo registrado correctamente en Azure AD B2C.');
    },
    error => {
      this._alert.sweetAlert('error', 'Ha ocurrido un error registrando el centro de costos en Azure AD B2C.');
    },
    () => {
      this.spinner = false;
    });
  }
}
