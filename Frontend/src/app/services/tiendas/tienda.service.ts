import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {
  API_URL: string = 'http://localhost:7680/api/tiendas';
  constructor(private httpClient: HttpClient) { }

  getTiendas(): Observable<any>{
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.get(this.API_URL+'/getAllTiendas', {headers}).pipe(res => res);
  }

  addTienda(Tienda: any): Observable<any> {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    
    return this.httpClient.post(`${this.API_URL}/createTienda`, Tienda, { headers });
  }

  updateTienda(Id: number, TiendaData: any) {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.put(`${this.API_URL}/updateTienda`, TiendaData,{headers});
  }
  
  deleteTienda(id: number | string) {
        const credentials = btoa('admin:admin'); // credenciales Basic Auth
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': `Basic ${credentials}`
        });
        return this.httpClient.delete(`${this.API_URL}/deleteTienda/`+id,{headers});
  }
}