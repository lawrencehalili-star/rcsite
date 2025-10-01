import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExamPermitComponent } from './exam-permit.component';

const routes: Routes = [
  {
    path: '',
    component: ExamPermitComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamPermitRoutingModule { }
