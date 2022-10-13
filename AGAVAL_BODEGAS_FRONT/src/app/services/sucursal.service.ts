import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISucursal } from '../interfaces/sucursal.interface';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SucursalService extends BaseService{

  constructor(http: HttpClient) { super(http); }

  searchSucursal(filter: string): Observable<Array<ISucursal>>{
    let endPoint: string = `${environment.Api}/api/sucursal?text=${filter}`;
    return this.doGet<Array<ISucursal>>(endPoint);
  }
}
