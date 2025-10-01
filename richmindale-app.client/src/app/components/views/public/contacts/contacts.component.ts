import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RecaptchaModule } from "ng-recaptcha";

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html'
})
export class ContactsComponent {

  constructor(private router: Router) {}

  GoToGrievance() : void {
    window.location.href = '/rims/grievance';
  }


}

