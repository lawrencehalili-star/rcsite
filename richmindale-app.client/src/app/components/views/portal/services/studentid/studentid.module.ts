import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentidRoutingModule } from './studentid-routing.module';
import { StudentidComponent } from './studentid.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    StudentidComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    StudentidRoutingModule
  ]
})
export class StudentidModule { }
