import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GrievancesRoutingModule } from './grievances-routing.module';
import { FormsModule } from '@angular/forms';
import { GrievancesComponent } from './grievances.component';


@NgModule({
  declarations: [
    GrievancesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    GrievancesRoutingModule
  ]
})
export class GrievancesModule { }
