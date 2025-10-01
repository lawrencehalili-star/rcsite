import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BalancesRoutingModule } from './balances-routing.module';
import { FormsModule } from '@angular/forms';
import { BalancesComponent } from './balances.component';


@NgModule({
  declarations: [
    BalancesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    BalancesRoutingModule
  ]
})
export class BalancesModule { }
