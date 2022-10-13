import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICentroCosto } from '../interfaces/centro-costo.interface';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CentrocostoService extends BaseService {

  constructor(http: HttpClient) { super(http); }

  searchCentroCosto(filter: string | null): Observable<Array<ICentroCosto>> {
    let endPoint: string = `${environment.Api}/api/centrocosto?text=${filter}`;
    return this.doGet<Array<ICentroCosto>>(endPoint);
  }
}
