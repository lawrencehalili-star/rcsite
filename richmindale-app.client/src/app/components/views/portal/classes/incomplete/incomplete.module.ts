import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IncompleteRoutingModule } from './incomplete-routing.module';
import { IncompleteComponent } from './incomplete.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    IncompleteComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    IncompleteRoutingModule
  ]
})
export class IncompleteModule { }
