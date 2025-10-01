import { Injectable } from '@angular/core';
import { environment } from '../../../../environment/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FinancialService {
  readonly apiUrl =  environment.API_URL + 'Student/';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  constructor(private http: HttpClient) { }

  loadStudentPaypalPayments(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadStudentPaypalPayments?id=' + id);
  }

}
