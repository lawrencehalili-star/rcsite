import { Component, OnInit } from '@angular/core';
import { PaypalTransactions } from '../../../../../shared/models/admin/finance/paypal-transactions.model';
import { FinanceService } from '../../../../../shared/services/admin/finance.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-paypal-transactions',
  templateUrl: './paypal-transactions.component.html'
})
export class PaypalTransactionsComponent implements OnInit {

  paypal: PaypalTransactions[] = [];

  constructor(private service: FinanceService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.service.loadPaypalPaymentTransactions().subscribe(res => { this.paypal = res; });
  }

}
