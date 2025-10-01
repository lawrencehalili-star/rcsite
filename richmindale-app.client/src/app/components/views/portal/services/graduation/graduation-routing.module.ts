import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GraduationComponent } from './graduation.component';

const routes: Routes = [
  {
    path: '',
    component: GraduationComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GraduationRoutingModule { }
