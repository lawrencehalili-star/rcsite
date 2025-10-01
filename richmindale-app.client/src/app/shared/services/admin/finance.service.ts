import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class FinanceService {
  readonly apiUrl =  environment.API_URL + 'Finance/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};
    
  constructor(private http: HttpClient) { }

  loadPaypalPaymentTransactions(): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadPaypalPaymentTransactions');
  }
}
