import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdmissionService {
  readonly apiUrl = environment.API_URL + 'Admission/';
  httpOptions = {
    headers: new HttpHeaders({
      Accept: 'application/json',
      'Content-Type': 'application/json; charset=utf-8',
    }),
  };
  validatePasskey: any;

  constructor(private http: HttpClient) {}

  // CORRECT ✅
  verifyEmail(email: any): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'VerifyEmail',
      { email: email },
      this.httpOptions
    );
  }

  //validatePasskey(email:any,passkey:any) : Observable<any> {
  //return this.http.post<any>(this.apiUrl + 'ValidatePasskey?email=' + email + '&passkey=' + passkey, this.httpOptions);
  //}

  verifyApplication(app: any): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'VerifyApplication',
      app,
      this.httpOptions
    );
  }

  loadAdmissionSummaryDetails(id: any): Observable<any> {
    return this.http.get<any>(
      this.apiUrl + 'LoadAdmissionSummaryDetails?id=' + id
    );
  }

  updateAdmissionApplication(adm: any): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'UpdateAdmissionApplication',
      adm,
      this.httpOptions
    );
  }

  submitAdmissionApplication(adm: any): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'SubmitAdmissionApplication',
      adm,
      this.httpOptions
    );
  }

  updateAdmissionPayment(paym: any): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'UpdateAdmissionPayment',
      paym,
      this.httpOptions
    );
  }

  loadAdmissionDocs(id: any): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadAdmissionDocs?id=' + id);
  }
}
