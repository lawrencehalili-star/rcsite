import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GrievanceRoutingModule } from './grievance-routing.module';
import { GrievanceComponent } from './grievance.component';
import { FormsModule } from '@angular/forms';
import { RecaptchaModule } from 'ng-recaptcha';


@NgModule({
  declarations: [
    GrievanceComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    RecaptchaModule,
    GrievanceRoutingModule
  ]
})
export class GrievanceModule { }
