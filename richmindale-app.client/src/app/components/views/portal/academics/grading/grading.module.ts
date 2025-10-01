import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GradingRoutingModule } from './grading-routing.module';
import { GradingComponent } from './grading.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GradingComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    GradingRoutingModule
  ]
})
export class GradingModule { }
