import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppealRoutingModule } from './appeal-routing.module';
import { AppealComponent } from './appeal.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppealComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AppealRoutingModule
  ]
})
export class AppealModule { }
