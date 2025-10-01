import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AttendanceRoutingModule } from './attendance-routing.module';
import { AttendanceComponent } from './attendance.component';
import { FormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';


@NgModule({
  declarations: [
    AttendanceComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DataTablesModule,
    AttendanceRoutingModule
  ]
})
export class AttendanceModule { }
