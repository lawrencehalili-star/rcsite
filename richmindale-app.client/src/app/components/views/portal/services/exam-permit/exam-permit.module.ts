import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamPermitRoutingModule } from './exam-permit-routing.module';
import { FormsModule } from '@angular/forms';
import { ExamPermitComponent } from './exam-permit.component';



@NgModule({
  declarations: [
    ExamPermitComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ExamPermitRoutingModule
  ]
})
export class ExamPermitModule { }
