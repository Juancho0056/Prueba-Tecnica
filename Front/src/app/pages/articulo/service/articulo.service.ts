import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {map, catchError, retry} from 'rxjs/operators';
import { Articulo } from '../model/Articulo';
import { Existencia } from '../model/Existencia';
import { HttpHeaders, HttpParams } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class ArticuloService {

  constructor(private _httpClient: HttpClient) { }

  /**public GetAll(): Observable<any>{
    const url = environment.apiUrl + environment.apiArticuloGetAll;
        return this._httpClient
          .get(url).pipe(
            map((res: Response) => {
              const body = res['data'];
              return { body } || {}
            })
          );
  }**/
  GetAll(): Observable<Existencia[]> {
    return this._httpClient.get<Existencia[]>(`${environment.apiUrl}${environment.apiArticuloGetAll}`);
  }
  public Get(id: number): Observable<Existencia>{
    const params = (id ? `?id=${id}` : '');
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
    const url = environment.apiUrl + environment.apiArticuloGet + params;
    return this._httpClient
         .get<Existencia>(url).pipe(
           retry(1),
           catchError(this.handleError));         
  }

  Create(articulo: Existencia): Observable<Existencia> {
    const url = environment.apiUrl + environment.apiArticuloCreate;
    return this._httpClient
    .post<Existencia>(url, articulo).pipe(
      retry(1),
      catchError(this.handleError));         
  }

  Update(articulo: Existencia): Observable<Existencia> {
    const url = environment.apiUrl + environment.apiArticuloUpdate;
    return this._httpClient
    .patch<Existencia>(url, articulo).pipe(
      retry(1),
      catchError(this.handleError));         
  }

  Delete(id: number): Observable<Existencia> {
    const params = (id ? `?id=${id}` : '');
    const url = environment.apiUrl + environment.apiArticuloDelete + params;
    return this._httpClient
    .delete<Existencia>(url).pipe(
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
