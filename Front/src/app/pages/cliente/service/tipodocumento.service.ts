import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {map, catchError, retry} from 'rxjs/operators';
import { TipoDocumento } from '../model/TipoDocumento';
import { HttpHeaders, HttpParams } from '@angular/common/http'; 
@Injectable({
  providedIn: 'root'
})
export class TipoDocumentoService {
  constructor(private _httpClient: HttpClient) { }
  public GetAll(): Observable<any>{
    const url = environment.apiUrl + environment.apiTipoDocumentoGetAll;
        return this._httpClient
          .get(url).pipe(
            map((res: Response) => {
              const body = res['data'];
              return { body } || {}
            })
          );
  }
  public Get(id: number): Observable<TipoDocumento>{
    const params = (id ? `?id=${id}` : '');
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    const url = environment.apiUrl + environment.apiTipoDocumentoGet + params;
    return this._httpClient
         .get<TipoDocumento>(url).pipe(
           retry(1),
           catchError(this.handleError));         
  }
  Create(tipoDocumento: TipoDocumento): Observable<TipoDocumento> {
    const url = environment.apiUrl + environment.apiTipoDocumentoCreate;
    return this._httpClient
    .post<TipoDocumento>(url, tipoDocumento).pipe(
      retry(1),
      catchError(this.handleError));         
  }
  Update(tipoDocumento: TipoDocumento): Observable<TipoDocumento> {
    const url = environment.apiUrl + environment.apiTipoDocumentoUpdate;
    return this._httpClient
    .patch<TipoDocumento>(url, tipoDocumento).pipe(
      retry(1),
      catchError(this.handleError));         
  }
  Delete(id: number): Observable<TipoDocumento> {
    const params = (id ? `?id=${id}` : '');
    const url = environment.apiUrl + environment.apiTipoDocumentoDelete + params;
    return this._httpClient
    .delete<TipoDocumento>(url).pipe(
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
