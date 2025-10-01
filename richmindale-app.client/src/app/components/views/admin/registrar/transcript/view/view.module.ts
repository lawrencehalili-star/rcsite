import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ViewRoutingModule } from './view-routing.module';
import { ViewComponent } from './view.component';
import { FormsModule } from '@angular/forms';


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
