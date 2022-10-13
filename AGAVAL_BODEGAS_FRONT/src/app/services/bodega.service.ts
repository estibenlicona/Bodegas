import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';
import { Bodega } from '../models/bodega.model';
import { Observable } from 'rxjs';
import { IApiResponse } from '../interfaces/api.response.interface';

@Injectable({
  providedIn: 'root'
})
export class BodegaService extends BaseService {

  constructor(http: HttpClient) { super(http); }

  public getBodegas(page: number, limit: number, tipo: string, sort?: string, direction?: string, filter?: string, column?: string, value?: string | number | boolean, start?: string, end?: string): Observable<IApiResponse<Bodega>> {
    let endPoint: string = `${environment.Api}/api/bodegas?page=${page}&size=${limit}&tipo=${tipo}`;

    if(sort != undefined && direction != undefined){
      endPoint += `&sort=${sort}&direction=${direction}`;
    }

    if(filter != undefined && column != undefined && value != undefined){
      endPoint += `&filter=${filter}&column=${column}&text=${value}`;
    }

    if(filter != undefined && column != undefined && start !=  undefined && end != undefined){
      endPoint += `&filter=${filter}&column=${column}&start=${start}&end=${end}`;
    }

    return this.doGet<IApiResponse<Bodega>>(endPoint);
  }

  public postBodega(bodega: Bodega){
    let endPoint = `${environment.Api}/api/bodegas`;
    return this.doPost(endPoint, bodega);
  }

  public getBodega(codigo: string) : Observable<Bodega>{
    let endPoint = `${environment.Api}/api/bodegas/${codigo}`;
    return this.doGet(endPoint);
  }

  public putBodega(bodega: Bodega){
    let endPoint = `${environment.Api}/api/bodegas`;
    return this.doPut(endPoint, bodega);
  }
}
