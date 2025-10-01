import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailsRoutingModule } from './details-routing.module';
import { FormsModule } from '@angular/forms';
import { DetailsComponent } from './details.component';
import { QrCodeModule } from 'ng-qrcode';
import { EnrollmentAgreementComponent } from '../../../../../templates/enrollment-agreement/enrollment-agreement.component';
import { EnrollmentAgreementRcComponent } from '../../../../../templates/enrollment-agreement-rc/enrollment-agreement-rc.component';



@NgModule({
  declarations: [
    DetailsComponent,
    EnrollmentAgreementComponent,
    EnrollmentAgreementRcComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    QrCodeModule,
    DetailsRoutingModule
  ]
})
export class DetailsModule { }
