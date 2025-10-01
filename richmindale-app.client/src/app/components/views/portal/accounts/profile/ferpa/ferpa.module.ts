import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FerpaRoutingModule } from './ferpa-routing.module';
import { FormsModule } from '@angular/forms';
import { FerpaComponent } from './ferpa.component';


@NgModule({
  declarations: [
    FerpaComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    FerpaRoutingModule
  ]
})
export class FerpaModule { }
