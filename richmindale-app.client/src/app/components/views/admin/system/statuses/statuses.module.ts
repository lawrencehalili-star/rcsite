import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatusesRoutingModule } from './statuses-routing.module';
import { StatusesComponent } from './statuses.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    StatusesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    StatusesRoutingModule
  ]
})
export class StatusesModule { }
