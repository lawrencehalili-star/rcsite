import { Injectable } from '@angular/core';
import { environment } from '../../../../environment/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassCardTemplatesService {
  readonly apiUrl =  environment.API_URL + 'Student/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  loadReportCardDetails(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadReportCardDetails?StudentId=' + id);
  }

}
