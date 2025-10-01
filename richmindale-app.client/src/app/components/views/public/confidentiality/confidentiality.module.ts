import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfidentialityRoutingModule } from './confidentiality-routing.module';
import { ConfidentialityComponent } from './confidentiality.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ConfidentialityComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ConfidentialityRoutingModule
  ]
})
export class ConfidentialityModule { }
