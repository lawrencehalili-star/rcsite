import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MasterlistRoutingModule } from './masterlist-routing.module';
import { MasterlistComponent } from './masterlist.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MasterlistComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    MasterlistRoutingModule
  ]
})
export class MasterlistModule { }
