import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TorViewRoutingModule } from './tor-view-routing.module';
import { FormsModule } from '@angular/forms';
import { TorViewComponent } from './tor-view.component';


@NgModule({
  declarations: [
    TorViewComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    TorViewRoutingModule
  ]
})
export class TorViewModule { }
