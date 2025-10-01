import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentAccountsRoutingModule } from './student-accounts-routing.module';
import { FormsModule } from '@angular/forms';
import { StudentAccountsComponent } from './student-accounts.component';


@NgModule({
  declarations: [
    StudentAccountsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    StudentAccountsRoutingModule
  ]
})
export class StudentAccountsModule { }
