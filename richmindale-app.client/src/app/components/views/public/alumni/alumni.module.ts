import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlumniRoutingModule } from './alumni-routing.module';
import { AlumniComponent } from './alumni.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AlumniComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AlumniRoutingModule
  ]
})
export class AlumniModule { }
