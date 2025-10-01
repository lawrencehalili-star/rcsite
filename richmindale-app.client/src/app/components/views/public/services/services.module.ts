import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServicesRoutingModule } from './services-routing.module';
import { FormsModule } from '@angular/forms';
import { ServicesComponent } from './services.component';


@NgModule({
  declarations: [
    ServicesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ServicesRoutingModule
  ]
})
export class ServicesModule { }
