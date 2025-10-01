import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditorRoutingModule } from './editor-routing.module';
import { EditorComponent } from './editor.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EditorComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    EditorRoutingModule
  ]
})
export class EditorModule { }
