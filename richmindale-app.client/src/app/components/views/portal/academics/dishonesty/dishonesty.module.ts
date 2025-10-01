import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DishonestyRoutingModule } from './dishonesty-routing.module';
import { DishonestyComponent } from './dishonesty.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DishonestyComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DishonestyRoutingModule
  ]
})
export class DishonestyModule { }
