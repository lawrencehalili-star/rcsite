import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GraduationRoutingModule } from './graduation-routing.module';
import { FormsModule } from '@angular/forms';
import { GraduationComponent } from './graduation.component';


@NgModule({
  declarations: [
    GraduationComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    GraduationRoutingModule
  ]
})
export class GraduationModule { }
