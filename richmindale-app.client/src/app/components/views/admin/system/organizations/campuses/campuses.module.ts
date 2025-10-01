import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CampusesRoutingModule } from './campuses-routing.module';
import { CampusesComponent } from './campuses.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CampusesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    CampusesRoutingModule
  ]
})
export class CampusesModule { }
