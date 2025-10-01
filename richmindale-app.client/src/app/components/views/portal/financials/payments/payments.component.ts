import { Component, OnInit } from '@angular/core';
import { FinancialService } from '../../../../../shared/services/portal/financial.service';
import { Payments } from '../../../../../shared/models/portal/financials/payments.model';
import { StorageService } from '../../../../../shared/services/auth/storage.service';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html'
})
export class PaymentsComponent implements OnInit {

   StudentId: any;
   payments: Payments[] = [];
   constructor(private storage: StorageService, private service: FinancialService) {}

   ngOnInit(): void {
     this.StudentId = this.storage.getSession('StudentId');
     this.service.loadStudentPaypalPayments(this.StudentId).subscribe(res => { this.payments = res; });
   }

}
