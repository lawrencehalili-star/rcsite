import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})


export class UploadService {
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type':'multipart/form-data' })};
  
  apiUrl = environment.API_URL;

  constructor(private http: HttpClient) { }

  uploadFileWithData(url:any,frmData: FormData) : Observable<any> {
    return this.http.post<any>(this.apiUrl + url, frmData, this.httpOptions);
  }

  uploadAdmissionFiles(frm:any) : Observable<any> {
    return this.http.post<any>(this.apiUrl + 'Admissions/UploadAdmissionFiles', frm, this.httpOptions);
  }

  

}
