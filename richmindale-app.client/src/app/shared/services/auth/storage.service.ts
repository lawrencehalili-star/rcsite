import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  saveSession(key:any,value:any) : void {
    window.localStorage.setItem(key, value);
  }

  getSession(key:any) : string | undefined {
    return window.localStorage.getItem(key)?.toString();
  }

  removeSession(key:any) : void {
    window.localStorage.removeItem(key);
  }

  clearSession() : void {
    window.localStorage.clear();
  }
}
