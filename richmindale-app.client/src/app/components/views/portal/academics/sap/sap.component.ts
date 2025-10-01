import { Component } from '@angular/core';

@Component({
  selector: 'app-sap',
  templateUrl: './sap.component.html'
})
export class SapComponent {

   constructor() {}

   CreateAppeal() : void {
     window.location.href = '/rims/sap/appeal';
   }

}
