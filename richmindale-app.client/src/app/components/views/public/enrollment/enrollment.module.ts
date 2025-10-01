import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EnrollmentRoutingModule } from './enrollment-routing.module';
import { EnrollmentComponent } from './enrollment.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EnrollmentComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    EnrollmentRoutingModule
  ]
})
export class EnrollmentModule { }
