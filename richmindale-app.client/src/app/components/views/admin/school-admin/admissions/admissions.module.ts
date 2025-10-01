import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdmissionsRoutingModule } from './admissions-routing.module';
import { AdmissionsComponent } from './admissions.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AdmissionsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AdmissionsRoutingModule
  ]
})
export class AdmissionsModule { }
