import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QrCodeModule } from 'ng-qrcode';
import { PaymentRoutingModule } from './payment-routing.module';
import { PaymentComponent } from './payment.component';
import { FormsModule } from '@angular/forms';
import { NgxPayPalModule } from 'ngx-paypal';


@NgModule({
  declarations: [
    PaymentComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    QrCodeModule,
    NgxPayPalModule,
    PaymentRoutingModule
  ]
})
export class PaymentModule { }
