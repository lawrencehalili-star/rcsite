import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportCardsRoutingModule } from './report-cards-routing.module';
import { FormsModule } from '@angular/forms';
import { ReportCardsComponent } from './report-cards.component';


@NgModule({
  declarations: [
    ReportCardsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReportCardsRoutingModule
  ]
})
export class ReportCardsModule { }
