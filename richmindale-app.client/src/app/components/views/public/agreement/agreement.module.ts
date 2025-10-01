import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AgreementRoutingModule } from './agreement-routing.module';
import { AgreementComponent } from './agreement.component';
import { FormsModule } from '@angular/forms';
import { PdfViewerModule } from 'ng2-pdf-viewer';


@NgModule({
  declarations: [
    AgreementComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PdfViewerModule,
    AgreementRoutingModule
  ]
})
export class AgreementModule { }
