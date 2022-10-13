import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Options {
  headers?: HttpHeaders;
  params?: HttpParams;
}

@Injectable({
  providedIn: 'root'
})

export class BaseService {

  constructor(protected http: HttpClient) { }

    protected defaultOpts = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    protected doGet<T>(serviceUrl: string): Observable<T> {
        return this.http.get(serviceUrl, this.defaultOpts).pipe(
            map(response => response as T)
        );
    }

    protected doPost<T, R>(serviceUrl: string, body: T): Observable<R> {

        return this.http.post(serviceUrl, body, this.defaultOpts).pipe(
            map(response => response as R)
        );
    }

    protected doPut<T, R>(serviceUrl: string, body: T): Observable<R> {

      return this.http.put(serviceUrl, body, this.defaultOpts).pipe(
          map(response => response as R)
      );
  }
}
