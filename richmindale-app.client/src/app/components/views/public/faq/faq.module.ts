import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FaqRoutingModule } from './faq-routing.module';
import { FaqComponent } from './faq.component';
import { FormsModule } from '@angular/forms';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    FaqComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    NgbAccordionModule,
    FaqRoutingModule
  ]
})
export class FaqModule { }
