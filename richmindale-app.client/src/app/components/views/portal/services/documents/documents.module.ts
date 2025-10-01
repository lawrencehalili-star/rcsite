import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DocumentsRoutingModule } from './documents-routing.module';
import { DocumentsComponent } from './documents.component';
import { DataTablesModule } from 'angular-datatables';





@NgModule({
  declarations: [
    DocumentsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DocumentsRoutingModule
  ]
})
export class DocumentsModule { }
