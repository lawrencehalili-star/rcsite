import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TranscriptRoutingModule } from './transcript-routing.module';
import { FormsModule } from '@angular/forms';
import { TranscriptComponent } from './transcript.component';


@NgModule({
  declarations: [
    TranscriptComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    TranscriptRoutingModule
  ]
})
export class TranscriptModule { }
