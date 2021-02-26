import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {map, catchError, retry} from 'rxjs/operators';
import { Cliente } from '../model/Cliente';
import { HttpHeaders, HttpParams } from '@angular/common/http'; 
@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  constructor(private _httpClient: HttpClient) { }
  public GetAll(): Observable<any>{
    const url = environment.apiUrl + environment.apiClienteGetAll;
        return this._httpClient
          .get(url).pipe(
            map((res: Response) => {
              const body = res['data'];
              return { body } || {}
            })
          );
  }
  public Get(id: number): Observable<Cliente>{
    const params = (id ? `?id=${id}` : '');
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    const url = environment.apiUrl + environment.apiClienteGet + params;
    return this._httpClient
         .get<Cliente>(url).pipe(
           retry(1),
           catchError(this.handleError));         
  }
  Create(cliente: Cliente): Observable<Cliente> {
    const url = environment.apiUrl + environment.apiClienteCreate;
    return this._httpClient
    .post<Cliente>(url, cliente).pipe(
      retry(1),
      catchError(this.handleError));         
  }
  Update(cliente: Cliente): Observable<Cliente> {
    const url = environment.apiUrl + environment.apiClienteUpdate;
    return this._httpClient
    .patch<Cliente>(url, cliente).pipe(
      retry(1),
      catchError(this.handleError));         
  }
  Delete(id: number): Observable<Cliente> {
    const params = (id ? `?id=${id}` : '');
    const url = environment.apiUrl + environment.apiClienteDelete + params;
    return this._httpClient
    .delete<Cliente>(url).pipe(
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
