import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrganizationsRoutingModule } from './organizations-routing.module';
import { FormsModule } from '@angular/forms';
import { OrganizationsComponent } from './organizations.component';


@NgModule({
  declarations: [
    OrganizationsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    OrganizationsRoutingModule
  ]
})
export class OrganizationsModule { }
