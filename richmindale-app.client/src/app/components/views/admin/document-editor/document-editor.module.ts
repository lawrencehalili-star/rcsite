import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocumentEditorRoutingModule } from './document-editor-routing.module';
import { FormsModule } from '@angular/forms';
import { DocumentEditorComponent } from './document-editor.component';


@NgModule({
  declarations: [
    DocumentEditorComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DocumentEditorRoutingModule
  ]
})
export class DocumentEditorModule { }
