import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuccessRoutingModule } from './success-routing.module';
import { FormsModule } from '@angular/forms';
import { SuccessComponent } from './success.component';


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
