import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LearningMethodsRoutingModule } from './learning-methods-routing.module';
import { FormsModule } from '@angular/forms';
import { LearningMethodsComponent } from './learning-methods.component';


@NgModule({
  declarations: [
    LearningMethodsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    LearningMethodsRoutingModule
  ]
})
export class LearningMethodsModule { }
