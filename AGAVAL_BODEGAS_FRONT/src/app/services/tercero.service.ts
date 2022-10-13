import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ITercero } from '../interfaces/tercero.interface';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TerceroService extends BaseService {

  constructor(http: HttpClient) { super(http); }

  search(filter: string) : Observable<Array<ITercero>>{
    let endPoint: string = `${environment.Api}/api/tercero?nit=${filter}`;
    return this.doGet<Array<ITercero>>(endPoint);
  }
}
