import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolAdminService {
  readonly apiUrl =  environment.API_URL + 'SchoolAdmin/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  loadAllAdmissionRequests(filter:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'LoadAllAdmissionRequests', filter, this.httpOptions);
  }

  loadCollegeAdmissionRequests(filter:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'LoadCollegeAdmissionRequests', filter, this.httpOptions);
  }

  loadAdmissionSummaryDetails(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadAdmissionSummaryDetails?id=' + id);
  }

  updateAdmissionStatus(id:any,status:any,reason:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'UpdateAdmissionStatus?id=' + id + '&status=' + status + '&reason=' + reason, this.httpOptions);
  }

  loadAgreementCourses(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadAgreementCourses?id=' + id);
  }
  
}
