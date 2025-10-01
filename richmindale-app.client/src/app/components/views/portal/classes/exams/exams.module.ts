import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamsRoutingModule } from './exams-routing.module';
import { FormsModule } from '@angular/forms';
import { ExamsComponent } from './exams.component';


@NgModule({
  declarations: [
    ExamsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ExamsRoutingModule
  ]
})
export class ExamsModule { }
