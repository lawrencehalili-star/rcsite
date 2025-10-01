import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProgramsRoutingModule } from './programs-routing.module';
import { ProgramsComponent } from './programs.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ProgramsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ProgramsRoutingModule
  ]
})
export class ProgramsModule { }
