import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxPayPalModule} from 'ngx-paypal';
import { PaypalRoutingModule } from './paypal-routing.module';
import { PaypalComponent } from './paypal.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PaypalComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    NgxPayPalModule,
    PaypalRoutingModule
  ]
})
export class PaypalModule { }
