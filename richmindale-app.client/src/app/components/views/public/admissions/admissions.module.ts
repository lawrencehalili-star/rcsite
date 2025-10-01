import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdmissionsRoutingModule } from './admissions-routing.module';
import { FormsModule } from '@angular/forms';
import { AdmissionsComponent } from './admissions.component';


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
