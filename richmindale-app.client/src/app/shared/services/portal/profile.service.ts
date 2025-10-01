import { Injectable } from '@angular/core';
import { environment } from '../../../../environment/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  readonly apiUrl =  environment.API_URL + 'Profile/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  getStudentProfile(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetStudentProfile?id=' + id);
  }

  updatePassword(id:any, pass:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'UpdatePassword?id=' + id + '&pass=' + pass, this.httpOptions);
  }

}
