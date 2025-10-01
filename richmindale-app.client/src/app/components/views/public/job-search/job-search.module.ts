import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobSearchRoutingModule } from './job-search-routing.module';
import { JobSearchComponent } from './job-search.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    JobSearchComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    JobSearchRoutingModule
  ]
})
export class JobSearchModule { }
