import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportCardRoutingModule } from './report-card-routing.module';
import { FormsModule } from '@angular/forms';
import { ReportCardComponent } from './report-card.component';


@NgModule({
  declarations: [
    ReportCardComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReportCardRoutingModule
  ]
})
export class ReportCardModule { }
