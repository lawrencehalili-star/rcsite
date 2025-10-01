import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgreementTemplatesComponent } from './agreement-templates.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AgreementTemplatesComponent
  ],
  imports: [
    FormsModule,
    CommonModule
  ]
})
export class AgreementTemplatesModule { }
