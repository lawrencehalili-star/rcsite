import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaRoutingModule } from './loa-routing.module';
import { FormsModule } from '@angular/forms';
import { DataTablesModule} from 'angular-datatables';


@NgModule({
  declarations: [],
  imports: [
    FormsModule,
    CommonModule,
    DataTablesModule,
    LoaRoutingModule
  ]
})
export class LoaModule { }
