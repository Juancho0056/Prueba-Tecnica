import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {map, catchError, retry} from 'rxjs/operators';
import { Factura } from '../model/Factura';
import { HttpHeaders, HttpParams } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  constructor(private _httpClient: HttpClient) { }
  public GetAll(): Observable<any>{
    const url = environment.apiUrl + environment.apiVentaGetAll;
        return this._httpClient
          .get(url).pipe(
            map((res: Response) => {
              const body = res['data'];
              return { body } || {}
            })
          );
  }
  public Get(id: number): Observable<Factura>{
    const params = (id ? `?id=${id}` : '');
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    const url = environment.apiUrl + environment.apiVentaGet + params;
    return this._httpClient
         .get<Factura>(url).pipe(
           retry(1),
           catchError(this.handleError));         
  }
  Create(factura: Factura): Observable<Factura> {
    const url = environment.apiUrl + environment.apiVentaCreate;
    return this._httpClient
    .post<Factura>(url, factura).pipe(
      retry(1),
      catchError(this.handleError));         
  }

  Delete(id: number): Observable<Factura> {
    const params = (id ? `?id=${id}` : '');
    const url = environment.apiUrl + environment.apiVentaDelete + params;
    return this._httpClient
    .delete<Factura>(url).pipe(
      retry(1),
      catchError(this.handleError));         
  }
  handleError(error)
  {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent)
    {
      errorMessage = error.error.message;
    } else
    {
      errorMessage = `Codigo error:  ${error.status}\nDescripcion: ${error.message}`
    }
    return throwError(errorMessage);
  }
}
