import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ContactsRoutingModule } from './contacts-routing.module';
import { ContactsComponent } from './contacts.component';
import { RecaptchaModule } from 'ng-recaptcha';


@NgModule({
  declarations: [
    ContactsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    RecaptchaModule,
    ContactsRoutingModule
  ]
})
export class ContactsModule { }
