import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudyloadRoutingModule } from './studyload-routing.module';
import { FormsModule } from '@angular/forms';
import { StudyloadComponent } from './studyload.component';


@NgModule({
  declarations: [
    StudyloadComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    StudyloadRoutingModule
  ]
})
export class StudyloadModule { }
