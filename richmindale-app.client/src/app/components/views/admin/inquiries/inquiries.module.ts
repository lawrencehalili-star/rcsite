import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InquiriesRoutingModule } from './inquiries-routing.module';
import { FormsModule } from '@angular/forms';
import { InquiriesComponent } from './inquiries.component';


@NgModule({
  declarations: [
    InquiriesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    InquiriesRoutingModule
  ]
})
export class InquiriesModule { }
