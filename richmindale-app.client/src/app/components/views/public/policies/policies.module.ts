import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PoliciesRoutingModule } from './policies-routing.module';
import { FormsModule } from '@angular/forms';
import { PoliciesComponent } from './policies.component';


@NgModule({
  declarations: [
    PoliciesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PoliciesRoutingModule
  ]
})
export class PoliciesModule { }
