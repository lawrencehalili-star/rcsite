import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrientationRoutingModule } from './orientation-routing.module';
import { OrientationComponent } from './orientation.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    OrientationComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    OrientationRoutingModule
  ]
})
export class OrientationModule { }
