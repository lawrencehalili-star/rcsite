import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '../../../../../../environment/environment';
import { IPayPalConfig, ICreateOrderRequest } from 'ngx-paypal';
import { ToastrService } from 'ngx-toastr';
import { AdmissionDetails } from '../../../../../shared/models/admin/admission-details.model';
import { AdmissionService } from '../../../../../shared/services/public/admission.service';
import { AdmissionPayment } from '../../../../../shared/models/public/admission-payment.model';


@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html'
})
export class PaymentComponent implements OnInit, OnDestroy {

  id:any;
  paramSubscription: Subscription =new Subscription();
  adm:AdmissionDetails = new AdmissionDetails();
  fullname:any;
  email: any;
  paym:AdmissionPayment = new AdmissionPayment();
  public paypalConfig?: IPayPalConfig;

  

  constructor(private route: ActivatedRoute, private service: AdmissionService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
    this.service.loadAdmissionSummaryDetails(this.id).subscribe(res => {
      this.adm = res;
      this.fullname = res.StudentGivenName + ' ' + res.StudentLastname;
      this.initConfig();
    });
  }

  ngOnDestroy(): void {
   
  }

  initConfig() : void {
       this.paypalConfig = {
        currency: 'USD',
        clientId: environment.payPal.clientId,
        createOrderOnClient: (data) => <ICreateOrderRequest> {
          intent: 'CAPTURE',
          purchase_units: [{
            amount: {
              currency_code: 'USD',
              value: '100',
              breakdown: {
                  item_total: {
                      currency_code: 'USD',
                      value: '100'
                  }
              }
            },
            items: [{
              name: 'Admission Number ' + this.adm.ApplicationRefNo + ';' + this.adm.EmailAddress + ';' + this.fullname,
              quantity: '1',
              category: 'DIGITAL_GOODS',
              unit_amount: {
                  currency_code: 'USD',
                  value: '100',
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
          actions.order.get().then((details:any) => {
              console.log('onApprove - you can get full order details inside onApprove: ', details);
              //this.toastr.success('Your transaction is currently on process.' +  details);
          });
  
        },
        onClientAuthorization: (data) => {
          console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
          //this.showSuccess = true;
          this.paym.Id = this.id;
          this.paym.Amount = 100;
          this.paym.PaymentRefNo = data.id;
          this.paym.EmailAddress = data.payer.email_address;
          this.paym.StudentName = this.fullname;
          this.paym.ApplicationRefNo = this.adm.ApplicationRefNo;
          this.paym.TermName = this.adm.TermName;
          
          this.service.updateAdmissionPayment(this.paym).subscribe(res => {
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
        },
        onClick: (data, actions) => {
          console.log('onClick', data, actions);
          //this.resetStatus();
        }
       }
    }

}
