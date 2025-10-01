import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolesRoutingModule } from './roles-routing.module';
import { RolesComponent } from './roles.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RolesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    RolesRoutingModule
  ]
})
export class RolesModule { }
