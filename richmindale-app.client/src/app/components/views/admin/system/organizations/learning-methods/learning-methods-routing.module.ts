import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LearningMethodsComponent } from './learning-methods.component';

const routes: Routes = [
  {
    path: '',
    component: LearningMethodsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LearningMethodsRoutingModule { }
