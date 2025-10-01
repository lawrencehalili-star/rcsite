import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChallengeRoutingModule } from './challenge-routing.module';
import { ChallengeComponent } from './challenge.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ChallengeComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ChallengeRoutingModule
  ]
})
export class ChallengeModule { }
