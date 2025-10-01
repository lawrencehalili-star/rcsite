import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaypalTransactionsComponent } from './paypal-transactions.component';

const routes: Routes = [
  {
    path: '',
    component: PaypalTransactionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaypalTransactionsRoutingModule { }
