import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ViewRoutingModule } from './view-routing.module';
import { FormsModule } from '@angular/forms';
import { ViewComponent } from './view.component';


@NgModule({
  declarations: [
    ViewComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ViewRoutingModule
  ]
})
export class ViewModule { }
