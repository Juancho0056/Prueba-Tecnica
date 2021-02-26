import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {map, catchError, retry} from 'rxjs/operators';
import { IUnidad } from '../model/IUnidad';
import { HttpHeaders, HttpParams } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class UnidadService {

  constructor(private _httpClient: HttpClient) { }

  public GetAll(): Observable<any>{
    const url = environment.apiUrl + environment.apiUnidadGetAll;
        return this._httpClient
          .get(url).pipe(
            map((res: Response) => {
              const body = res['data'];
              return { body } || {}
            })
          );
  }

  public Get(id: number): Observable<IUnidad>{
    const params = (id ? `?id=${id}` : '');
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    const url = environment.apiUrl + environment.apiUnidadGet + params;
    return this._httpClient
         .get<IUnidad>(url).pipe(
           retry(1),
           catchError(this.handleError));         
  }

  Create(unidad: IUnidad): Observable<IUnidad> {
    const url = environment.apiUrl + environment.apiUnidadCreate;
    return this._httpClient
    .post<IUnidad>(url, unidad).pipe(
      retry(1),
      catchError(this.handleError));         
  }

  Update(unidad: IUnidad): Observable<IUnidad> {
    const url = environment.apiUrl + environment.apiUnidadUpdate;
    return this._httpClient
    .patch<IUnidad>(url, unidad).pipe(
      retry(1),
      catchError(this.handleError));         
  }

  Delete(id: number): Observable<IUnidad> {
    const params = (id ? `?id=${id}` : '');
    const url = environment.apiUrl + environment.apiUnidadDelete + params;
    return this._httpClient
    .delete<IUnidad>(url).pipe(
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
