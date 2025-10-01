import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {

  requestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.requestCount++;
    this.spinnerService;
    this.spinnerService.show(undefined, {
      type: 'fire',
      bdColor: 'rgba(0,0,0,0.8)',
      size: 'medium',
      color: '#fff',
      fullScreen: true
    });
  }

  idle() {
    this.requestCount--;
    if(this.requestCount <= 0) {
      this.requestCount = 0;
      this.spinnerService.hide();
    }
   
  }
}
