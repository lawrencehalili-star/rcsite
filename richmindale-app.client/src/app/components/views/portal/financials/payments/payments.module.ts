import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaymentsRoutingModule } from './payments-routing.module';
import { FormsModule } from '@angular/forms';
import { PaymentsComponent } from './payments.component';


@NgModule({
  declarations: [
    PaymentsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PaymentsRoutingModule
  ]
})
export class PaymentsModule { }
