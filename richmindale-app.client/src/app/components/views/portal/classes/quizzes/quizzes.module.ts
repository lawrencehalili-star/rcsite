import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizzesRoutingModule } from './quizzes-routing.module';
import { FormsModule } from '@angular/forms';
import { QuizzesComponent } from './quizzes.component';


@NgModule({
  declarations: [
    QuizzesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    QuizzesRoutingModule
  ]
})
export class QuizzesModule { }
