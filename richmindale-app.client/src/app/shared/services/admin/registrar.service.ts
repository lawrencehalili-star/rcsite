import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrarService {
  readonly apiUrl =  environment.API_URL + 'Registrar/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};
    
  constructor(private http: HttpClient) { }

  loadPaginatedMasterlist(filter:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'LoadPaginatedMasterlist', filter, this.httpOptions);
  }

  loadAllAdmissionRequests(filter:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'LoadAllAdmissionRequests', filter, this.httpOptions);
  }

  updateAdmissionStatus(id:any,status:any,reason:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'UpdateAdmissionStatus?id=' + id + '&status=' + status + '&reason=' + reason, this.httpOptions);
  }

}
