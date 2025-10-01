import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibraryRoutingModule } from './library-routing.module';
import { LibraryComponent } from './library.component';
import { FormsModule } from '@angular/forms';


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
