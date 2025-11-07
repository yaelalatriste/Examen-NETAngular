import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ArticuloService {
  API_URL: string = 'http://localhost:7680/api/articulos';
  constructor(private httpClient: HttpClient) { }

  getArticulos(): Observable<any>{
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.get(this.API_URL+'/getAllArticulos', {headers}).pipe(res => res);
  }

  addArticulo(Articulo: any): Observable<any> {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    
    return this.httpClient.post(`${this.API_URL}/createArticulo`, Articulo, { headers });
  }

  updateArticulo(Id: number, ArticuloData: any) {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.put(`${this.API_URL}/updateArticulo`, ArticuloData,{headers});
  }
  
  deleteArticulo(id: number | string) {
        const credentials = btoa('admin:admin'); // credenciales Basic Auth
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': `Basic ${credentials}`
        });
        return this.httpClient.delete(`${this.API_URL}/deleteArticulo/`+id,{headers});
  }
}