import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TranscriptRoutingModule } from './transcript-routing.module';
import { TranscriptComponent } from './transcript.component';
import { FormsModule } from '@angular/forms';


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
