import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BodegaService } from 'src/app/services/bodega.service';
import { MatSort } from '@angular/material/sort';
import { FilterType } from 'src/app/enums/filtertype.enum';
import { IFilter } from 'src/app/interfaces/filter.interface';
import { Bodega } from 'src/app/models/bodega.model';
import { IB2C } from 'src/app/interfaces/b2c.interface';
import { B2cService } from 'src/app/services/b2c.service';
import { AlertService } from 'src/app/services/alert.service';
import { EnumTipoCupo } from 'src/app/enums/tipocupo.enum';

@Component({
  selector: 'app-centro-costo-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListarBodegasComponent implements OnInit, AfterViewInit  {

  displayedColumns: string[] = [
    'codigo', 'nombre', 'codigoSucursal', 'nombreSucursal', 'telefono', 'direccion', 'centrocosto', 'nit', 'correo',
    'codigoCiudad','sector','representantelegal', 'inicioFacturacion', 'porcentjeComision', 'diasPago',
    'validaReferencias', 'recibeAbonos', 'tipoCupo', 'fechaActivacion','fechaInActivacion', 'edit', 'b2c', 'activo'
  ];
  dataSource = new MatTableDataSource<Bodega>();
  tipo: string = 'aliado';
  @ViewChild(MatPaginator) paginator: MatPaginator = new MatPaginator(new MatPaginatorIntl(), ChangeDetectorRef.prototype, { pageSize: 10 });

  @ViewChild(MatSort) sort!: MatSort;
  filter!: IFilter;
  filterActivo: boolean = false;
  active!: string;
  direction!: string;
  spinner: boolean = false;

  constructor(
    private _bodega: BodegaService,
    private _b2c: B2cService,
    private _alert: AlertService
  ) {

  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.list();
  }

  list(){
    this.spinner = true;
    this._bodega.getBodegas(
      this.paginator.pageIndex,
      this.paginator.pageSize,
      this.tipo,
      this.active,
      this.direction,
      this.filter?.type,
      this.filter?.column,
      this.filter?.value,
      this.filter?.start,
      this.filter?.end
    ).subscribe( resp => {
      this.paginator.length = resp.count;
      this.dataSource = new MatTableDataSource<Bodega>(resp.body);
    },
      error => {
        this._alert.sweetAlert('error', 'Ha ocurrido un error cargando los datos.');
      },
      () => {
        this.spinner = false;
      }
    );
  }

  OnChangePage() {
    this.list()
  }

  OnSortData(){
    //Update sort
    this.active = this.sort.active;
    this.direction = this.sort.direction;

    this.list();
  }

  changefilterEvent(filter: IFilter){
    this.filter = filter;
    this.list();
    this.paginator.firstPage();
  }

  edit(bodega: Bodega){
    console.log(bodega)
  }

  sendB2c(codigoCentroCosto: string, codigoSucursal: string, nombreCentroCosto: string, nombresucursal: string, porcentajeComision: number, tipoCupo: EnumTipoCupo){
    this.spinner = true;
    debugger
    let b2c: IB2C = {
      codigoCentroCosto: codigoCentroCosto,
      codigoSucursal: codigoSucursal,
      nombreCentroCosto: nombreCentroCosto,
      nombreSucursal: nombresucursal,
      porcentajeComision: porcentajeComision,
      tipoCupo: tipoCupo
    }
    this._b2c.postB2C(b2c).subscribe(resp => {
      this._alert.sweetAlert('success', 'Datos enviados correctamente.');
    },
    error => {
      this._alert.sweetAlert('error', 'Ha ocurrido un error enviando los datos.');
    },
    () => {
      this.spinner = false;
    });
  }
  public get FilterType(): typeof FilterType {
    return FilterType;
  }

}
