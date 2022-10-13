import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IB2C } from '../interfaces/b2c.interface';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class B2cService extends BaseService {

  constructor(http: HttpClient) { super(http); }

  public postB2C(b2c: IB2C){
    let endPoint = `${environment.Api}/api/b2c/registro`;
    return this.doPost(endPoint, b2c);
  }
}
