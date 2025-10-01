import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LedgerRoutingModule } from './ledger-routing.module';
import { LedgerComponent } from './ledger.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    LedgerComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    LedgerRoutingModule
  ]
})
export class LedgerModule { }
