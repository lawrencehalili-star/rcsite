import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AcademicsRoutingModule } from './academics-routing.module';
import { FormsModule } from '@angular/forms';
import { AcademicsComponent } from './academics.component';


@NgModule({
  declarations: [
    AcademicsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AcademicsRoutingModule
  ]
})
export class AcademicsModule { }
