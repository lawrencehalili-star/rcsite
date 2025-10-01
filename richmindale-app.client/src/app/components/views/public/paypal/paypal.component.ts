import { Component, OnInit } from '@angular/core';
import { IPayPalConfig, ICreateOrderRequest } from 'ngx-paypal';
import { environment } from '../../../../../environment/environment'; 
import { ToastrService } from 'ngx-toastr';
import { PublicService } from '../../../../shared/services/public/public.service';
import { PaypalPayment } from '../../../../shared/models/public/paypal-payment.model';

@Component({
  selector: 'app-paypal',
  templateUrl: './paypal.component.html'
})
export class PaypalComponent {

  public paypalConfig?: IPayPalConfig;
  email:any;
  name:any;
  transaction:any;
  admissionId:any;
  admissionFee:any;
  paypal:PaypalPayment = new PaypalPayment();

  constructor(private toastr: ToastrService, private service: PublicService) {}

  ngOnInit(): void {
      this.initConfig();
    
  }

  onAmountChange() : void {
    this.initConfig();
  }

  initConfig() : void {
     this.paypalConfig = {
      currency: 'USD',
      clientId: environment.payPal.clientId,
      createOrderOnClient: data => <ICreateOrderRequest> {
        intent: 'CAPTURE',
        purchase_units: [{
          amount: {
            currency_code: 'USD',
            value: this.admissionFee,
            breakdown: {
                item_total: {
                    currency_code: 'USD',
                    value: this.admissionFee
                }
            }
          },
          items: [{
            name: this.transaction + ';' +  this.email + ';' + this.name,
            quantity: '1',
            category: 'DIGITAL_GOODS',
            unit_amount: {
                currency_code: 'USD',
                value: this.admissionFee,
            },
          }]
        }]
      },
      advanced: {
        commit: 'true'
      },
      style: {
        label: 'paypal',
        layout: 'vertical'
      },
      onApprove: (data, actions) => {
        console.log('onApprove - transaction was approved, but not authorized', data, actions);
        console.log('Data ', JSON.stringify(data));
        actions.order.get().then((details:any) => {
            //console.log('onApprove - you can get full order details inside onApprove: ', details);
            console.log('Details', JSON.stringify(details));
            //this.toastr.success('Your transaction successfully processed.' +  details);
             
        }).then((orderData:any) => {
          console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
          var errorDetail = Array.isArray(orderData.errors) && orderData.errors[0];
          if(errorDetail && errorDetail.message === 'ISSUER_DECLINE') {
            //this.toastr.error("Transaction Declined!");
            return actions.restart();
          }

          if(errorDetail) {
            var msg = 'Sorry, your couldnot be processed.';
            if(errorDetail.description) msg += "\n\n" + errorDetail.description;
            if(orderData.debug_id) msg += ' (' + orderData.debug_id + ')';
            this.toastr.error(msg);
            this.paypal.TransactionMessage = msg;
          }

          console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
          var transaction = orderData.purchase_units[0].payments.captures[0];
          //alert('Transaction ' + transaction.status + ': ' + transaction.id);
          
          this.paypal.TransactionNumber = transaction.id;
          this.paypal.Status = transaction.status;
          this.paypal.PaymentFor = this.transaction;
          this.paypal.EmailAddress = this.email;
          this.paypal.Amount = this.admissionFee;
          
          
          this.service.savePaypalPayment(this.paypal).subscribe(res => {
            if(res.status === 'success') {
              this.toastr.success(res.msg);
            } else {
              this.toastr.error(res.msg);
            }
          });

        });

      },
      onClientAuthorization: data => {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
        //this.showSuccess = true;
        this.paypal.TransactionNumber = data.id;
        this.paypal.Status = data.status;
        this.paypal.PaymentFor = this.transaction;
        this.paypal.EmailAddress = this.email;
        this.paypal.Amount = this.admissionFee;
        this.paypal.TransactionMessage = data.status;
        
        this.service.savePaypalPayment(this.paypal).subscribe(res => {
          if(res.status === 'success') {
            this.toastr.success(res.msg);
          } else {
            this.toastr.error(res.msg);
          }
        });
        
      },
      onCancel: (data, actions) => {
        console.log('OnCancel', data, actions);
        //this.showCancel = true;
        
      },
      onError: err => {
        console.log('OnError', err);
        this.toastr.error(err);
        this.paypal.TransactionNumber = "";
        this.paypal.Status = "error";
        this.paypal.PaymentFor = this.transaction;
        this.paypal.EmailAddress = this.email;
        this.paypal.Amount = this.admissionFee;
        this.paypal.TransactionMessage = err;
        this.toastr.error(err);
        this.service.savePaypalPayment(this.paypal).subscribe(res => {
          if(res.status === 'success') {
            this.toastr.success(res.msg);
          } else {
            this.toastr.error(res.msg);
          }
        });
      },
      onClick: (data, actions) => {
        console.log('onClick', data, actions);
        //this.resetStatus();
      }
     }
  }

}
