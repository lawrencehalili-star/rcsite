import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuccessRoutingModule } from './success-routing.module';
import { SuccessComponent } from './success.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SuccessComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    SuccessRoutingModule
  ]
})
export class SuccessModule { }
