import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaypalTransactionsRoutingModule } from './paypal-transactions-routing.module';
import { PaypalTransactionsComponent } from './paypal-transactions.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PaypalTransactionsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PaypalTransactionsRoutingModule
  ]
})
export class PaypalTransactionsModule { }
