import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  readonly apiUrl =  environment.API_URL + 'Common/';
  httpOptions = { headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json; charset=utf-8' })};

  constructor(private http: HttpClient) { }

  getCountries() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCountries');
  }

  getUSCountry() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetUSCountry');
  }

  getDegreeCategory() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetDegreeCategory');
  }

  getUsLearningMethod() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetUsLearningMethod');
  }

  getStatesByCountryId(id?:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetStatesByCountryId?id=' + id);
  } 

  getCitiesByStateId(id?:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCitiesByStateId?id=' + id);
  }

  getCommonDropdown(grp:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCommonDropdown?grp=' + grp);
  }

  getProgramByCategoryId(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetProgramByCategoryId?id=' + id);
  }

  getProgramsWithCode(grp:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetProgramsWithCode?grp=' + grp);
  }

  getCommonDropdownByParent(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCommonDropdownByParent?id=' + id);
  }

  getStatusDropdown(grp:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetStatusDropdown?grp=' + grp);
  }

  getCampusCountries() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCampusCountries');
  }

  getCampusByCountry(id?:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCampusByCountry?id=' + id);
  }

  getLearningMethods() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetLearningMethods');
  }

  getMaritalStatus() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetMaritalStatus');
  }

  getReligions() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetReligions');
  }

  getNationality() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetNationality');
  }

  getPhoneCodes() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetPhoneCodes');
  }

  getDocumentTypes() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetDocumentTypes');
  }

  getDocumentAmount(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetDocumentAmount?id=' + id);
  }

  getProgramsByCategoryId(id?:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetProgramsByCategoryId?id=' + id);
  }

  getAvailableCoursesByProgram(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetAvailableCoursesByProgram?id=' + id);
  }

  getCoursesByTermsProgram(terms:any, program:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetCoursesByTermsProgram?terms=' + terms + '&program=' + program);
  }

  loadUploadedCourses(search:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadUploadedCourses?search=' + search);
  }

  getProgramDetails(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetProgramDetails?id=' + id);
  }

  getProgramWithDetails() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetProgramWithDetails');
  }

  loadProgramSemesterCourses(id:any) : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'LoadProgramSemesterCourses?id=' + id);
  }

  getGradeLevelPrograms() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetGradeLevelPrograms');
  }

  getGradeLevelPeriods() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetGradeLevelPeriods');
  }

  getGradeLevelCredentials() : Observable<any> {
    return this.http.get<any>(this.apiUrl + 'GetGradeLevelCredentials');
  }

}
