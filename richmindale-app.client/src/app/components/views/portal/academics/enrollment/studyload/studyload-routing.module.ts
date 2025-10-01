import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudyloadComponent } from './studyload.component';

const routes: Routes = [
  {
    path: '',
    component: StudyloadComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudyloadRoutingModule { }
