import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { FormsModule } from '@angular/forms';
import { CategoriesComponent } from './categories.component';


@NgModule({
  declarations: [
    CategoriesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
