import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DetailsRoutingModule } from './details-routing.module';
import { DetailsComponent } from './details.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DetailsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DetailsRoutingModule
  ]
})
export class DetailsModule { }
