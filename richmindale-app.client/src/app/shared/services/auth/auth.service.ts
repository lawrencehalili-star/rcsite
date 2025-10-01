import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly apiUrl =  environment.API_URL + 'Authentication/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  authenticateAdmin(username:any, password:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'AuthenticateAdmin?username=' + username + '&password=' + password, this.httpOptions);
  }

  authenticateStudent(username:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'AuthenticateStudent?username=' + username, this.httpOptions);
  }

  validatePasskey(username:any, key:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'ValidatePasskey?username=' + username + '&passkey=' + key, this.httpOptions);
  }

  getUserInfo(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetUserInfo?id=' + id);
  }
   
}

