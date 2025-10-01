import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PublicService {
  readonly apiUrl =  environment.API_URL + 'Public/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  verifyEmail(email:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'VerifyEmail?EmailAddress=' + email, this.httpOptions);
  }

  validatePasskey(email:any, passkey:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'ValidatePasskey?email=' + email + '&passkey=' + passkey, this.httpOptions);
  }

  submitGrievance(grieve:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'SubmitGrievance', grieve, this.httpOptions);
  }

  saveEnrollmentRequest(enroll:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'SaveEnrollmentRequest', enroll, this.httpOptions);
  }

  savePaypalPayment(data:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'SavePaypalPayment', data, this.httpOptions);
  }

}
