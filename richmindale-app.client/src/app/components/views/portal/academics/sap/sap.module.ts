import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SapRoutingModule } from './sap-routing.module';
import { FormsModule } from '@angular/forms';
import { SapComponent } from './sap.component';


@NgModule({
  declarations: [
    SapComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    SapRoutingModule
  ]
})
export class SapModule { }
