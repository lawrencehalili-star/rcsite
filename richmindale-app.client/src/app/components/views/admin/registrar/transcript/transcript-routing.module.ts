import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TranscriptComponent } from './transcript.component';

const routes: Routes = [
  {
    path: '',
    component: TranscriptComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TranscriptRoutingModule { }
