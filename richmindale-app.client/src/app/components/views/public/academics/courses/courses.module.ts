import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { FormsModule } from '@angular/forms';
import { CoursesComponent } from './courses.component';


@NgModule({
  declarations: [
    CoursesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    CoursesRoutingModule
  ]
})
export class CoursesModule { }
