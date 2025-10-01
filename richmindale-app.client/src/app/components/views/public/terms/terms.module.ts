import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TermsRoutingModule } from './terms-routing.module';
import { TermsComponent } from './terms.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TermsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    TermsRoutingModule
  ]
})
export class TermsModule { }
