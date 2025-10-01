import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibraryRoutingModule } from './library-routing.module';
import { FormsModule } from '@angular/forms';
import { LibraryComponent } from './library.component';


@NgModule({
  declarations: [
    LibraryComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    LibraryRoutingModule
  ]
})
export class LibraryModule { }
