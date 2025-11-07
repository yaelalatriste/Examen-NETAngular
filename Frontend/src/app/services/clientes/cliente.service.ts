import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  API_URL: string = 'http://localhost:7680/api/clientes';
  constructor(private httpClient: HttpClient) { }

  getClientes(): Observable<any>{
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.get(this.API_URL+'/getAllClientes', {headers}).pipe(res => res);
  }

  addCliente(Cliente: any): Observable<any> {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    
    return this.httpClient.post(`${this.API_URL}/createCliente`, Cliente, { headers });
  }

  updateCliente(Id: number, ClienteData: any) {
    const credentials = btoa('admin:admin'); // credenciales Basic Auth
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Basic ${credentials}`
    });
    return this.httpClient.put(`${this.API_URL}/updateCliente`, ClienteData,{headers});
  }
  
  deleteCliente(id: number | string) {
        const credentials = btoa('admin:admin'); // credenciales Basic Auth
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': `Basic ${credentials}`
        });
        return this.httpClient.delete(`${this.API_URL}/deleteCliente/`+id,{headers});
  }
}